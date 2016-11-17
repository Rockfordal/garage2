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
    public class SlotsController : Controller
    {
        private GarageDb db = new GarageDb();

        public ActionResult Test()
        {
            int x = 1;
            var s = x.ToString("0000");
            return Content(s);
        }

        // GET: Slots
        public ActionResult Index()
        {
            return View(db.Slots.ToList());
        }

        // GET: Slots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            return View(slot);
        }

        // GET: Slots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PID,Location")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                db.Slots.Add(slot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slot);
        }

        // GET: Slots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListOfGarages = db.Garages;
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PID,Location,Garage")] Slot slot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var st = ModelState;
                var error = ModelState.Values.Last().Errors.Last().ErrorMessage;
                var exception = ModelState.Values.Last().Errors.Last().Exception;
                return Content("Nått gick fel: <br/>" + error + "<br/> exception: <br/>" +  exception);
            }
            ViewBag.ListOfGarages = db.Garages;
            return View(slot);
        }

        // GET: Slots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            return View(slot);
        }

        // POST: Slots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slot slot = db.Slots.Find(id);
            db.Slots.Remove(slot);
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
