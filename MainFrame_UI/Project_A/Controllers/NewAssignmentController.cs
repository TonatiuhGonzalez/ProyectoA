using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_A.Controllers
{
    public class NewAssignmentController : Controller
    {
        // GET: NewAssignment
        public ActionResult New()
        {
            return View();
        }
    }
}