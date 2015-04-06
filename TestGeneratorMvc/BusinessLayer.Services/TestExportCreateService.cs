using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;
using DataLayer.ExportModel;
using DataLayer.Interfaces;
using DataLayer.Model;
using TestExportHelper;

namespace BusinessLayer.Services
{
    public class TestExportCreateService : ITestExportCreateService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITestRepository m_TestRepository;
        private ITestExportRepository m_TestExportRepository;

        public TestExportCreateService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestRepository = m_UnitOfWork.GetRepository<ITestRepository>();
            m_TestExportRepository = m_UnitOfWork.GetRepository<ITestExportRepository>();
        }

        public ApiShowTestExportAfterCreate Export(ApiCreateTestExport createTextExport, string path)
        {
            Test test = m_TestRepository.GetByIdWithQuestionsAndAnswers(createTextExport.TestId);
            ExportHelper helper = new ExportHelper(path, createTextExport.NumberOfVariants, Mapper.Map<ExportTest>(test));
            if (helper.Export())
            {
                TestExport testExport = new TestExport();
                testExport.NumberOfVariants = createTextExport.NumberOfVariants;
                testExport.Path = helper.PathToZipArchive;
                testExport.VirtualPath = string.Format("/Export/{0}", helper.ZipArchiveName);
                testExport.TestId = createTextExport.TestId;
                var testExportFromDb = m_TestExportRepository.Create(testExport);
                m_UnitOfWork.SaveChanges();
                return Mapper.Map<ApiShowTestExportAfterCreate>(testExportFromDb);
            }
            return null;
        }
    }
}
