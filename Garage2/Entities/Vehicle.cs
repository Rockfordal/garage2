using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public enum VehicleType
    {
        Car, Boat, Bike, Truck
    }

    public class Vehicle
    {
        public int Id { get; set; }

        public string RegNr { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int NumberOfWheels { get; set; }

        public VehicleType VehicleType { get; set; }
        public Slot Slot { get; set; }
        public Owner Owner { get; set; }
    }
}