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
using Garage2.Data;

// kernel.Bind<ISlotRepository>().To<SlotRepository>().InRequestScope();
// kernel.Bind<IVehicleRepository>().To<VehicleRepository>().InRequestScope();

namespace Garage2.Controllers
{
    public class VehiclesController : ApplicationController
    {
        private readonly GarageDbContext _context;
        private readonly VehicleRepository _vehicle;

        //private IVehicleRepository _repo;

        //public VehiclesController(IVehicleRepository repo)
        public VehiclesController()
        {
            _context = new GarageDbContext();
            _vehicle = new VehicleRepository();
        }

        // GET: Select
        public ActionResult Select(bool ownage)
        {
            MainRepository.Ownage = ownage;
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            ViewBag.VehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();
            ViewBag.Ownage = MainRepository.Ownage;

            var vehicles = _vehicle.GetVehicles(MainRepository.Ownage);
            return View(vehicles);
        }

        // POST: Vehicles
        [HttpPost]
        public ActionResult Index(string searchString, string typeString)
        {
            ViewBag.VehicleTypes = Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();
            ViewBag.type = typeString;
            ViewBag.Search = searchString;
            //ViewBag.Ownage = MainRepository.Ownage;

            var vehicles = _vehicle.Search(searchString, typeString);
            return View(vehicles);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = _context.Vehicles
                .Include(v => v.Owner)
                .Include(v => v.Slot)
                .SingleOrDefault(v => v.Id == id);
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
        public ActionResult Create([Bind(Include = "Id,RegNr,Manufacturer,Model,Color,NumberOfWheels,Year,VehicleType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
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
            Vehicle vehicle = _context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var slots = _context.Slots;
            var slotList = slots.ToList();

            if (_context.Vehicles.ToList().Count() == 0)
            {
                return Content("Hittade inga slots");
            }

            //return Content(slotList.Count().ToString());
            //ViewBag.Slots = new SelectList(slotList, "Id", "PID");
            //ViewBag.Slots = slotList;

            var slotQuery = from s in _context.Slots select s;

            if (vehicle.Slot != null)
                ViewBag.Slot = new SelectList(slotQuery, "Id", "PID", vehicle.Slot.Id);
            else
                ViewBag.Slot = new SelectList(slotQuery, "Id", "PID", null);
            //selectedSlot = PopulateSlotsDropDownList(selectedSlot;

            var veh = new EditVehicleVM();
            veh.Id = vehicle.Id;
            veh.Manufacturer = vehicle.Manufacturer;
            veh.Model = vehicle.Model;
            veh.NumberOfWheels = vehicle.NumberOfWheels;
            veh.Owner = vehicle.Owner;
            veh.RegNr = vehicle.RegNr;
            veh.VehicleType = vehicle.VehicleType;
            veh.Year = vehicle.Year;
            //veh.Slots = (SelectListItem) slotQuery.ToList();

            //var selectedId = null;
            //slotQuery.ToSelectItems(selectdId);

            //IEnumerable<Slot> ieslots = db.Slots;
            //IEnumerable<SelectListItem> sellistitems = (IEnumerable<SelectListItem>) ieslots;
            //veh.Slots = new SelectList(  sellistitems, "Id", "PID");

            //veh.Slots = new SelectList(
            //    db.Slots.ToSelectListItems(null)
            //);

            //veh.Slots = new SelectList(db.Slots, "Id", "PID");

            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNr,Manufacturer,Model,Color,NumberOfWheels,Year,VehicleType,Slot, Slot_Id")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(vehicle).State = EntityState.Modified;
                //var testSlot = db.Slots.Find(4);
                //var slot = vehicle.Slot;
                //vehicle.Slot = testSlot;
                var v = vehicle;
                _context.SaveChanges();
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
            Vehicle vehicle = _context.Vehicles.Find(id);
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
            Vehicle vehicle = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateSlotsDropDownList(object selectedSlot = null)
        {
            var slotQuery = from s in _context.Slots
                                   // orderby d.Name
                                   select s;
            ViewBag.SlotID = new SelectList(slotQuery, "SlotId", "Name", selectedSlot);
            //ViewBag.Slots = new SelectList(slotList, "Id", "PID");
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
