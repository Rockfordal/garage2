using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public static class MainRepository
    {
        private static Garage _selectedGarage = null;
        private static Owner _selectedOwner  = null;

        private static GarageRepository _garage = new GarageRepository();
        private static OwnerRepository _owner = new OwnerRepository();
        //private static GarageDb _db = new GarageDb();

        public static Garage selectedGarage
        { 
            get
            {
                if (_selectedGarage == null)
                {
                    _selectedGarage = _garage.GimmeAGarage();
                }
                    
                return _selectedGarage;
            }
            set
            {
                _selectedGarage = value;
            }
        }

        public static Owner selectedOwner
        { 
            get
            {
                if (_selectedOwner == null)
                {
                    _selectedOwner = _owner.GimmeOwner();
                }

                return _selectedOwner;
            }
            set
            {
                _selectedOwner = value;
            }
        }

        public static void Seed(GarageDb db)
        {
            //var kurt = new Owner() { FirstName = "Kurt", LastName = "Ohlsson" };
            //db.Owners.Add(kurt);

            var phuset = new Garage() {  Name = "P-Huset", NumberOfSlots = 10 };
            db.Garages.Add(phuset);
            phuset.GenerateSlots(phuset);

            var falmark = new Garage() { Name = "Falmark", NumberOfSlots = 10 };
            db.Garages.Add(falmark);
            phuset.GenerateSlots(falmark);

            //var entre1 = new Slot() { Garage = phuset, Location = "Vid entrén", PID = "E01" };
            //db.Slots.Add(entre1);

            //var baksidan = new Slot() { Garage = phuset, Location = "Baksidan", PID = "B01" };
            //db.Slots.Add(baksidan);

            //var v1 = new Vehicle()
            //{
            //    Color = "Röd",
            //    Manufacturer = "Ferarri",
            //    Model = "Enzo",
            //    RegNr = "ENZ401",
            //    Owner = kurt,
            //    VehicleType = VehicleType.Car,
            //    Year = 1995
            //};

            //var v2 = new Vehicle()
            //{
            //    Color = "Svart",
            //    Manufacturer = "Audi",
            //    Model = "RS8",
            //    RegNr = "AUD301",
            //    Owner = kurt,
            //    VehicleType = VehicleType.Car,
            //    Year = 1999
            //};

            //db.Vehicles.Add(v1);
            //db.Vehicles.Add(v2);

            db.SaveChanges();
        }
    }
}