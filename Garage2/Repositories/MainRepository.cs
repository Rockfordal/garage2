using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public class MainRepository
    {
        public void Seed(GarageDb db)
        {
            var kurt = new Owner() { FirstName = "Kurt", LastName = "Ohlsson" };
            db.Owners.Add(kurt);

            var phuset = new Garage() { Name = "P-Huset", NumberOfSlots = 10 };
            db.Garages.Add(phuset);

            var entre1 = new Slot() { Garage = phuset, Location = "Vid entrén" };
            db.Slots.Add(entre1);

            var entre2 = new Slot() { Garage = phuset, Location = "Vid entrén" };
            db.Slots.Add(entre2);

            db.Vehicles.Add(new Vehicle() { Color="Röd",   Manufacturer="Ferarri", Model="Enzo", RegNr="ENZ401",
                                             Owner=kurt, VehicleType=VehicleType.Car, Year=1995 });

            db.Vehicles.Add(new Vehicle() { Color="Svart", Manufacturer="Audi", Model="RS8", RegNr="AUD301", 
                                             Owner=kurt, VehicleType=VehicleType.Car, Year=1999 });

            db.SaveChanges();
        }
    }
}