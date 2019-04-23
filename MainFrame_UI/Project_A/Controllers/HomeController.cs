using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_A.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Personal autorizado y asignaciones realizadas";

            return View();
        }

        public ActionResult Devices()
        {
            ViewBag.Message = "Estado de activos";

            return View();
        }
    }
}