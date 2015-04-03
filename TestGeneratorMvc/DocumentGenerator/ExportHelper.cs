using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ExportModel;
using DataLayer.Model;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Ionic.Zip;

namespace TestExportHelper
{
    public class ExportHelper
    {
        #region Members

        private int m_Id;
        private string m_Path;
        private string m_FileName;
        private int m_NumberOfVariants;
        private ExportTest m_Test;
        private List<ExportTestForOutput> m_Tests = new List<ExportTestForOutput>();

        #endregion

        #region Properties

        public string PathToTemporaryFolder
        {
            get
            {
                return Path.Combine(m_Path, m_FileName);
            }
        }

        public string ZipArchiveName
        {
            get
            {
                return string.Format("{0}.zip", m_FileName);
            }
        }

        public string PathToZipArchive
        {
            get
            {
                return Path.Combine(m_Path, ZipArchiveName);
            }
        }

        private int Id
        {
            get
            {
                m_Id += 1;
                return m_Id;
            }
        }

        #endregion

        public ExportHelper(string path, int numberOfVariants, ExportTest test)
        {
            m_Path = path;
            m_FileName = Guid.NewGuid().ToString();
            m_NumberOfVariants = numberOfVariants;
            m_Test = test;
            if (!Directory.Exists(PathToTemporaryFolder))
            {
                Directory.CreateDirectory(PathToTemporaryFolder);
            }
        }

        public bool Export()
        {
            try
            {
                GenerateTests();
                CreateDocuments();
                ZipFiles();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DeleteFolder();
            }
        }

        #region Zip files

        private void ZipFiles()
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddItem(PathToTemporaryFolder);
                zip.Save(PathToZipArchive);
            }
        }

        #endregion

        #region Create documents

        private void CreateDocument(ExportTestForOutput test)
        {
            string filePath = Path.Combine(PathToTemporaryFolder, string.Format("{0}.docx", test.Id));
            using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();

                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph parag;
                Run run;
                Text text;
                parag = body.AppendChild(new Paragraph());
                run = parag.AppendChild(new Run());
                run.AppendChild(new Text(test.Name));
                parag = body.AppendChild(new Paragraph());
                run = parag.AppendChild(new Run());
                run.AppendChild(new Text(string.Format("№ {0} Имя  _______________________________________________________  Баллы  ____", test.Id)));
                for(int i = 0; i < test.Questions.Count; i++)
                {
                    parag = body.AppendChild(new Paragraph());
                    run = parag.AppendChild(new Run());
                    text = new Text(test.Questions[i].GetString(i + 1));
                    run.AppendChild(text);
                }
            }
        }

        private void CreateDocuments()
        {
            foreach (var test in m_Tests)
            {
                CreateDocument(test);
            }
        }
        #endregion

        #region Generate tests

        private void GenerateTests()
        {
            for (var i = 0; i < m_NumberOfVariants; i++)
            {
                m_Tests.Add(GenerateTest());
            }
        }

        private ExportTestForOutput GenerateTest()
        {
            var result = new ExportTestForOutput
            {
                Id = Id,
                Name = m_Test.Name,
                Questions = new List<ExportQuestion>(m_Test.Questions.Permute(m_Test.CountOfQuestions))
            };
            for (var index = 0; index < result.Questions.Count; index++)
            {
                result.Questions[index] = GenerateQuestion(result.Questions[index]);
            }
            return result;
        }

        private ExportQuestion GenerateQuestion(ExportQuestion question)
        {
            var correct = question.Answers.Where(a => a.IsCorrect).Permute(m_Test.CountOfRightAnswers);
            var incorrect = question.Answers.Where(a => !a.IsCorrect).Permute(m_Test.CountOfAnswers - m_Test.CountOfRightAnswers);
            return new ExportQuestion
            {
                Text = question.Text,
                Answers = new List<ExportAnswer>(correct.Union(incorrect).Permute(m_Test.CountOfAnswers))
            };
        }
        #endregion

        public void DeleteFolder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(PathToTemporaryFolder);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
            Directory.Delete(PathToTemporaryFolder);
        }
    }
}
