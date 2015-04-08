using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using DataLayer.ApiModel;

namespace TestGeneratorMvc.Controllers.ApiControllers
{
    public class TestExportController : ApiController
    {
        private ITestExportCreateService m_TestExportCreateService;
        private ITestExportEditService m_TestExportEditService;
        private ITestExportViewService m_TestExportViewService;
        private ITestViewService m_TestViewService;

        public TestExportController()
        {
            m_TestExportCreateService = DependencyResolver.Current.GetService<ITestExportCreateService>();
            m_TestExportEditService = DependencyResolver.Current.GetService<ITestExportEditService>();
            m_TestExportViewService = DependencyResolver.Current.GetService<ITestExportViewService>();
            m_TestViewService = DependencyResolver.Current.GetService<ITestViewService>();
        }

        public List<ApiShowTestExportWithTestInfo> GetTestExportsWithTestInfo()
        {
            return m_TestExportViewService.GetTestExportsWithTestInfo();
        }

        public int GetTestExportsCount()
        {
            return m_TestExportViewService.GetTestExportsCount();
        }

        public List<ApiShowTest> GetTestsForTestExportCreate()
        {
            return m_TestViewService.GetTests();
        }

        [System.Web.Http.HttpPost]
        public string DeleteTestExport(ApiBaseEntity testExport)
        {
            return m_TestExportEditService.DeleteTestExport(testExport.Id);
        }

        [System.Web.Http.HttpPost]
        public ApiShowTestExportAfterCreate AddTestExport(ApiCreateTestExport testExport)
        {
            String path = HttpContext.Current.Server.MapPath("~/Exports/");
            return m_TestExportCreateService.Export(testExport, path);
        }
    }
}
