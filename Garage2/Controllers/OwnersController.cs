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
using Garage2.Data;

namespace Garage2.Controllers
{
    public class OwnersController : ApplicationController
    {
        private readonly OwnerRepository _owner;
        private readonly GarageDbContext _context;

        public OwnersController()
        {
            _owner   = new OwnerRepository();
            _context = new GarageDbContext();
        }

        // GET: Seed
        public ActionResult Seed()
        {
            Garage2.Data.MainRepository.Seed(_context);
            return Content("Seed klar (förhoppningsvis)");
        }

        // GET: Select
        public ActionResult Select(int? id)
        {
            if (id != null)
            {
                int ownerId = (int) id;
                MainRepository.selectedOwner = _owner.GetOwnerByID(ownerId);
            }
            var o = MainRepository.selectedOwner;
            //if (o != null)
            //{
            //    return Content(MainRepository.selectedOwner.FullName);
            //} else {
            //    return Content("ägare blev inte satt");
            //}
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Owners
        public ActionResult Index()
        {
            return View(_context.Owners.ToList());
        }

        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = _context.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Owners.Add(owner);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = _context.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(owner).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = _context.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = _context.Owners.Find(id);
            _context.Owners.Remove(owner);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
