using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Students()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}