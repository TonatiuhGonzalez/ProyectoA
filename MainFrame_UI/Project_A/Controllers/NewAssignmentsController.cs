using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_A.Models;

namespace Project_A.Controllers
{
    public class NewAssignmentsController : Controller
    {

        // GET: NewAssignments
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(string empleado)
        {
            NewAssignment newAssignment = new NewAssignment() {NPersonal = empleado };
            //acciones para pobtener datos
           


            return View(newAssignment);

        }
    }
}


        
