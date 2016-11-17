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
        //public static Garage selectedGarage = null;
        private static Garage _selectedGarage = null;
        private static GarageRepository _garage = new GarageRepository();
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

        public static void Seed(GarageDb db)
        {
            var kurt = new Owner() { FirstName = "Kurt", LastName = "Ohlsson" };
            db.Owners.Add(kurt);

            var phuset = new Garage() {  Name = "P-Huset", NumberOfSlots = 10 };
            db.Garages.Add(phuset);

            var falmark = new Garage() { Name = "Falmark", NumberOfSlots = 10 };
            db.Garages.Add(falmark);

            var entre1 = new Slot() { Garage = phuset, Location = "Vid entrén", PID = "E01" };
            db.Slots.Add(entre1);

            var baksidan = new Slot() { Garage = phuset, Location = "Baksidan", PID = "B01" };
            db.Slots.Add(baksidan);

            db.Vehicles.Add(new Vehicle() { Color="Röd",   Manufacturer="Ferarri", Model="Enzo", RegNr="ENZ401",
                                             Owner=kurt, VehicleType=VehicleType.Car, Year=1995 });

            db.Vehicles.Add(new Vehicle() { Color="Svart", Manufacturer="Audi", Model="RS8", RegNr="AUD301", 
                                             Owner=kurt, VehicleType=VehicleType.Car, Year=1999 });

            db.SaveChanges();
        }
    }
}