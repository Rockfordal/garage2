using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Garage2.Repositories
{
    public class VehicleRepository
    {
        private GarageDb db = new GarageDb();

        public IEnumerable<Vehicle> GetMyParkableVehicles(bool ownage)
        {
            var ownerIdString = MainRepository.selectedOwner.Id.ToString();
            var vehicles = db.Vehicles
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
            var allVehicles = db.Vehicles
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

            var vehicles = db.Vehicles
                .Include("Owner")
                .Include("Slot")
                .Where(v => (
                        (v.Manufacturer == searchString || searchString == "")
                     && (v.VehicleType.ToString() == typeString || typeString == "")
                     && (v.Owner.Id.ToString() == ownerIdString)
                       ))
                .ToList();
            return vehicles;
        }

    }
}