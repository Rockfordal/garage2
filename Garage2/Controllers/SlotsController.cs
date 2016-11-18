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
    public class SlotsController : ApplicationController
    {
        private readonly SlotRepository _slot;
        private readonly VehicleRepository _vehicle;
        private readonly GarageDbContext _context;

        public SlotsController()
        {
            _slot = new SlotRepository();
            _vehicle = new VehicleRepository();
            _context = new GarageDbContext();
        }

        public ActionResult Test()
        {
            //int x = 1;
            //var s = x.ToString("0000");
            var s = new RandomRegnr().gimme();
            return Content(s);
        }

        // GET: Slots
        public ActionResult Index()
        {
            ViewBag.Vehicles = _vehicle.GetVehicles(true);
            var slots = new List<Slot>();
            if (Garage2.Data.MainRepository.selectedGarage != null)
            {
                var currentGarageId = Garage2.Data.MainRepository.selectedGarage.Id;
                slots = _context.Slots.Include("Vehicle").Where(s => s.Garage.Id == currentGarageId).ToList();
            } else
            {
                slots = _context.Slots.Include("Vehicle").ToList();
            }
            return View(slots.OrderBy(s => s.PID));
        }

        // GET: Slots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = _context.Slots.Find(id);
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
                _context.Slots.Add(slot);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slot);
        }

        public ActionResult ViewLyubomir(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ModalSlot = _context.Slots.Find(id);
            if (ViewBag.ModalSlot == null)
            {
                return HttpNotFound();
            }
            //return View(slot);
            
            return PartialView("SlotDetails");
        }

        [HttpPost]
        public ActionResult Lyubomir()
        {
            return RedirectToAction("Index");
        }

        // GET: Slots/Park
        public ActionResult Park(int id, int v_id)
        {
            if (ModelState.IsValid)
            {
                _slot.Park(id, v_id);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Slots/Park
        public ActionResult UnPark(int id)
        {
            if (ModelState.IsValid)
            {
                _slot.UnPark(id);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Slots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Slot slot = _context.Slots.Find(id);
            if (slot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListOfGarages = _context.Garages;
            return View(slot);
        }

        // POST: Slots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PID,Location,Garage")] Slot slot)
        {
            ViewBag.ListOfGarages = _context.Garages;
            if (ModelState.IsValid)
            {
                _context.Entry(slot).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var st = ModelState;
                var error = ModelState.Values.Last().Errors.Last().ErrorMessage;
                var exception = ModelState.Values.Last().Errors.Last().Exception;
                return Content("Nått gick fel: <br/>" + error + "<br/> exception: <br/>" +  exception);
            }
            //return View(slot);
        }

        // GET: Slots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slot slot = _context.Slots.Find(id);
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
            Slot slot = _context.Slots.Find(id);
            _context.Slots.Remove(slot);
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
