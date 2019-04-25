using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_A;

namespace Project_A.Controllers
{
    public class AssignmentsController : Controller
    {
        private inventoryEntitiesDB db = new inventoryEntitiesDB();

        // GET: Assignments
        public ActionResult Index()
        {
            var assignments = db.Assignments.Include(a => a.App_Users).Include(a => a.App_Users1).Include(a => a.Device_Types).Include(a => a.Proyect).Include(a => a.State).Include(a => a.User);
            return View(assignments.ToList());
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            ViewBag.responsible_down_id = new SelectList(db.App_Users, "id", "name");
            ViewBag.responsible_up_id = new SelectList(db.App_Users, "id", "name");
            ViewBag.device_type_id = new SelectList(db.Device_Types, "id", "type");
            ViewBag.proyect_id = new SelectList(db.Proyects, "id", "proyect1");
            ViewBag.state_id = new SelectList(db.States, "id", "state1");
            ViewBag.user_id = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,user_id,device_type_id,device_id,state_id,proyect_id,responsive_number,responsible_up_id,responsible_down_id,ticket_number_up,ticket_number_down,create_at,edit_at")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.responsible_down_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_down_id);
            ViewBag.responsible_up_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_up_id);
            ViewBag.device_type_id = new SelectList(db.Device_Types, "id", "type", assignment.device_type_id);
            ViewBag.proyect_id = new SelectList(db.Proyects, "id", "proyect1", assignment.proyect_id);
            ViewBag.state_id = new SelectList(db.States, "id", "state1", assignment.state_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", assignment.user_id);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.responsible_down_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_down_id);
            ViewBag.responsible_up_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_up_id);
            ViewBag.device_type_id = new SelectList(db.Device_Types, "id", "type", assignment.device_type_id);
            ViewBag.proyect_id = new SelectList(db.Proyects, "id", "proyect1", assignment.proyect_id);
            ViewBag.state_id = new SelectList(db.States, "id", "state1", assignment.state_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", assignment.user_id);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,device_type_id,device_id,state_id,proyect_id,responsive_number,responsible_up_id,responsible_down_id,ticket_number_up,ticket_number_down,create_at,edit_at")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.responsible_down_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_down_id);
            ViewBag.responsible_up_id = new SelectList(db.App_Users, "id", "name", assignment.responsible_up_id);
            ViewBag.device_type_id = new SelectList(db.Device_Types, "id", "type", assignment.device_type_id);
            ViewBag.proyect_id = new SelectList(db.Proyects, "id", "proyect1", assignment.proyect_id);
            ViewBag.state_id = new SelectList(db.States, "id", "state1", assignment.state_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "name", assignment.user_id);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
