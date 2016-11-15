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
using Garage2.Repositories;

namespace Garage2.Controllers
{
    public class GaragesController : Controller
    {
        static private GarageDb db = new GarageDb();
        private GarageRepository repo = new GarageRepository(db);

        // GET: Seed
        public ActionResult Seed()
        {
            new MainRepository().Seed(db);
            return Redirect("Index");
        }

        // GET: Garages
        public ActionResult Index()
        {
            return View(db.Garages.ToList());
        }

        // GET: Garages/Details/5
        public ActionResult Details(int? id, int? r)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            if(r != null)
                repo.GenerateSlots(garage, db);
            return View(garage);
        }

        // GET: Garages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NumberOfSlots")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                repo.GenerateSlots(garage, db);
                db.Garages.Add(garage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garage);
        }

        // GET: Garages/Edit/5
        public ActionResult Edit(int? id, int? r)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            if(r == 1)
            {
                repo.GenerateSlots(garage, db);
                db.SaveChanges();
            }
            return View(garage);
        }

        // POST: Garages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NumberOfSlots")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garage);
        }

        // GET: Garages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garage garage = db.Garages.Find(id);
            db.Garages.Remove(garage);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateSlots(int id)
        {
            repo.GenerateSlots(db.Garages.Find(id), db);
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
