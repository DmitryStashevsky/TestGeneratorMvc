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
        private IUserRepository m_UserRepository;

        public TestExportCreateService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestRepository = m_UnitOfWork.GetRepository<ITestRepository>();
            m_TestExportRepository = m_UnitOfWork.GetRepository<ITestExportRepository>();
            m_UserRepository = m_UnitOfWork.GetRepository<IUserRepository>();
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
                //TO-DO correct path
                testExport.VirtualPath = string.Format("/Exports/{0}", helper.ZipArchiveName);
                //atach user
                //var user = new User { Id = createTextExport.UserId }
                //m_UserRepository.Attach(new User { Id = createTextExport.UserId });
                testExport.TestId = createTextExport.TestId;
                testExport.OwnerId = createTextExport.OwnerId;
                var testExportFromDb = m_TestExportRepository.Create(testExport);
                m_UnitOfWork.SaveChanges();
                return Mapper.Map<ApiShowTestExportAfterCreate>(testExportFromDb);
            }
            return null;
        }
    }
}
