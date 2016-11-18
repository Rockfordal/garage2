using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage2.Data;

namespace Garage2.Data
{

    public class VehicleRepository : IVehicleRepository
    {
        private readonly GarageDbContext _context;

        public VehicleRepository()
        {
            _context = new GarageDbContext();
        }

        public IEnumerable<Vehicle> GetMyParkableVehicles(bool ownage)
        {
            var ownerIdString = MainRepository.selectedOwner.Id.ToString();
            var vehicles = _context.Vehicles
                .Include("Owner")
                .Include("Slot")
                .Where(v => (
                         (v.Owner.Id.ToString() == ownerIdString) 
                      && (v.Slot == null)
                      ));
                
                return vehicles.ToList();
        }

        public IEnumerable<Vehicle> GetVehicles(bool ownage)
        {
            var ownerIdString = MainRepository.selectedOwner.Id.ToString();
            var allVehicles = _context.Vehicles
                .Include("Owner")
                .Include("Slot");

            if (ownage)
            {
                var myVehicles = allVehicles.Where(v => (
                         (v.Owner.Id.ToString() == ownerIdString) ));

                
                return myVehicles.ToList();
            }
            else
            {
                var otherVehicles = allVehicles.Where(v => (
                         (v.Owner.Id.ToString() != ownerIdString) ));
                return otherVehicles.ToList();
            }
        }

        public IEnumerable<Vehicle> Search(string searchString, string typeString)
        {
            var ownerIdString = MainRepository.selectedOwner.Id.ToString();

            var vehicles = _context.Vehicles
                .Include("Owner")
                .Include("Slot")
                .Where(v => (
                        (searchString == "" || v.Manufacturer == searchString || v.Model == searchString || v.RegNr == searchString) 
                     && (v.VehicleType.ToString() == typeString || typeString == "")
                     && (v.Owner.Id.ToString() == ownerIdString)
                       ))
                .ToList();
            return vehicles;
        }

    }
}