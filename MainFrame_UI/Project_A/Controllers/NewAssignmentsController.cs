using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_A.Models;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Project_A.Controllers
{
    public class NewAssignmentsController : Controller
    {
        inventoryEntitiesDB inventarioEntities = new inventoryEntitiesDB();
        // GET: NewAssignments
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(string id, string activo)
        {
            NewAssignment newAssignment = new NewAssignment() {NPersonal = id };
            //acciones para pobtener datos
            /*string searchString = id;
            var newAssignment = from m in db.Users
                                select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                newAssignment = newAssignment.Where(s => s.Title.Contains(searchString));
            }
            */

            return View(newAssignment);

        }
    }
}


        
