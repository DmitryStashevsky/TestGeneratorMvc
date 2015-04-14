using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestGeneratorMvc.Controllers
{
    [Authorize(Roles="Admin, Trainer")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tests()
        {
            return View();
        }

        public ActionResult AddTest()
        {
            return View();
        }

        public ActionResult TestExports()
        {
            return View();
        }

        public ActionResult AddTestExport()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }

        public ActionResult AddQuestion()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult Users()
        {
            return View();
        }
    }
}
