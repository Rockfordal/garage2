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

        public IEnumerable<Vehicle> GetMyVehicles()
        {
            var ownerIdString = MainRepository.selectedOwner.Id.ToString();
            var vehicles = db.Vehicles
                .Include("Owner")
                .Include("Slot")
                .Where(v => (
                     (v.Owner.Id.ToString() == ownerIdString)
                       ))
                .ToList();
            return vehicles;
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