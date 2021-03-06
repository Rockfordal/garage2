﻿using System;
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
    public class GaragesController : ApplicationController
    {
        private readonly GarageRepository _garage;

        public GaragesController()
        {
            _garage = new GarageRepository();
        }

        // GET: Seed
        public ActionResult Seed()
        {
            MainRepository.Seed(new GarageDbContext());
            return Content("Seed utförd");
        }

        // GET: Select
        public ActionResult Select(int? id)
        {
            if (id != null)
            {
                int myid = (int) id;
                MainRepository.selectedGarage = _garage.GetGarageByID(myid);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Garages
        public ActionResult Index()
        {
            return View(_garage.GetAllGarages());
        }

        // GET: Garages/Details/5
        public ActionResult Details(int? id)
        {
            return View(_garage.GetGarageByIdWithSlots(id.Value));
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
                _garage.CreateGarage(garage);
                return RedirectToAction("Index");
            }
            return View(garage);
        }

        // GET: Garages/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_garage.GetGarageByID(id.Value));
        }

        // POST: Garages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NumberOfSlots")] Garage garage)
        {
            return View(garage);
        }

        // GET: Garages/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(_garage.GetGarageByID(id.Value));
        }

        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _garage.DeleteGarage(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _garage.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
