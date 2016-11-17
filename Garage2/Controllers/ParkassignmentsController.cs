using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccess;
using Garage2.Entities;

namespace Garage2.Controllers
{
    public class ParkassignmentsController : Controller
    {
        private GarageDb db = new GarageDb();

        // GET: Parkassignments
        public ActionResult Index()
        {
            return View(db.Parkassignments.ToList());
        }

        // GET: Parkassignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parkassignment parkassignment = db.Parkassignments.Find(id);
            if (parkassignment == null)
            {
                return HttpNotFound();
            }
            return View(parkassignment);
        }

        // GET: Parkassignments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parkassignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Parkassignment parkassignment)
        {
            if (ModelState.IsValid)
            {
                db.Parkassignments.Add(parkassignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkassignment);
        }

        // GET: Parkassignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parkassignment parkassignment = db.Parkassignments.Find(id);
            if (parkassignment == null)
            {
                return HttpNotFound();
            }
            return View(parkassignment);
        }

        // POST: Parkassignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Parkassignment parkassignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkassignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkassignment);
        }

        // GET: Parkassignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parkassignment parkassignment = db.Parkassignments.Find(id);
            if (parkassignment == null)
            {
                return HttpNotFound();
            }
            return View(parkassignment);
        }

        // POST: Parkassignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parkassignment parkassignment = db.Parkassignments.Find(id);
            db.Parkassignments.Remove(parkassignment);
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
