using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Model;
using TestExportHelper;

namespace BusinessLayer.Services
{
    public class TestExportEditService : ITestExportEditService
    {
        private IUnitOfWork m_UnitOfWork;
        private ITestExportRepository m_TestExportRepository;

        public TestExportEditService(IUnitOfWork unitOfWork)
        {
            m_UnitOfWork = unitOfWork;
            m_TestExportRepository = m_UnitOfWork.GetRepository<ITestExportRepository>();
        }

        public string DeleteTestExport(Guid testExportId)
        {
            TestExport testExport = m_TestExportRepository.GetById(testExportId);
            ExportHelper.DeleteTestExport(testExport.Path);
            m_TestExportRepository.Delete(testExport);
            m_UnitOfWork.SaveChanges();
            return "Successfully deleted test export";
        }
    }
}
