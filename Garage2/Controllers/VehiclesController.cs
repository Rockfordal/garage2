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
using Garage2.Models;
//using Garage2.Extensions;

namespace Garage2.Controllers
{
    public class VehiclesController : ApplicationController
    {
        private GarageDb db = new GarageDb();

        // GET: Vehicles
        public ActionResult Index()
        {
            ViewBag.VehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();
            return View(db.Vehicles.Include("Owner").Include("Slot").ToList());
        }

        // POST: Vehicles
        [HttpPost]
        public ActionResult Index(string search, string type)
        {
            ViewBag.VehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();
            ViewBag.type = type;

            ViewBag.Search = search;
            var vehicles = db.Vehicles
                .Where(v => (
                        (v.Manufacturer == search || search == "")
                     && (v.VehicleType.ToString() == type || type == "")
                       ))
                .Include("Owner")
                .Include("Slot")
                .ToList();
            return View(vehicles);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNr,Model,Color,NumberOfWheels,Year,VehicleType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var slots = db.Slots;
            var slotList = slots.ToList();

            if (db.Vehicles.ToList().Count() == 0)
            {
                return Content("Hittade inga slots");
            }

            //return Content(slotList.Count().ToString());
            //ViewBag.Slots = new SelectList(slotList, "Id", "PID");
            //ViewBag.Slots = slotList;

            //var slotQuery = from s in db.Slots select s;

            //if (vehicle.Slot != null)
            //    ViewBag.Slot = new SelectList(slotQuery, "Id", "PID", vehicle.Slot.Id);
            //else
            //    ViewBag.Slot = new SelectList(slotQuery, "Id", "PID");

            //ViewBag.Slot = new SelectList(slotList, "Id", "PID");
            //selectedSlot = PopulateSlotsDropDownList(selectedSlot;
            //IEnumerable<SelectListItem> sels = new IEnumerable<SelectListItem>();

            var veh = new EditVehicleVM();
            veh.Id = vehicle.Id;
            veh.Manufacturer = vehicle.Manufacturer;
            veh.Model = vehicle.Model;
            veh.NumberOfWheels = vehicle.NumberOfWheels;
            veh.Owner = vehicle.Owner;
            veh.RegNr = vehicle.RegNr;
            veh.VehicleType = vehicle.VehicleType;
            veh.Year = vehicle.Year;
            //veh.Slots = (SelectListItem)slotQuery.ToList();

            //var selectedId = null;
            //slotQuery.ToSelectItems(selectdId);

            //IEnumerable<Slot> ieslots = db.Slots;
            //IEnumerable<SelectListItem> sellistitems = (IEnumerable<SelectListItem>) ieslots;
            //veh.Slots = new SelectList(  sellistitems, "Id", "PID");

            //veh.Slots = new SelectList(
            //    db.Slots.ToSelectListItems(null)
            //);

            //veh.Slots = new SelectList(db.Slots, "Id", "PID");

            IEnumerable<Slot> ss = db.Slots;

            //veh.Slots = db.Slots.ToSelectItems(null);

            //veh.Slots = new SelectList(db.Slots, "ID", "Name");

            //veh.Slots = db.Slots.ToList();

            return View(vehicle);
        }


        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Vehicle vehicle, Slot Slot)
        public ActionResult Edit([Bind(Include = "Id,RegNr,Manufacturer,Model,Color,NumberOfWheels,Year,VehicleType,Slot, Slot_Id")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                //var testSlot = db.Slots.Find(4);
                //var slot = vehicle.Slot;
                //vehicle.Slot = testSlot;
                var v = vehicle;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateSlotsDropDownList(object selectedSlot = null)
        {
            var slotQuery = from s in db.Slots
                                   // orderby d.Name
                                   select s;
            ViewBag.SlotID = new SelectList(slotQuery, "SlotId", "Name", selectedSlot);
            //ViewBag.Slots = new SelectList(slotList, "Id", "PID");
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
