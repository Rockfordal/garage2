using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public int Id { get; set; }

        [Required, DisplayName("Regnummer")]
        public string RegNr { get; set; }

        [DisplayName("Tillverkare")]
        public string Manufacturer { get; set; }

        [DisplayName("Modell")]
        public string Model { get; set; }

        [DisplayName("Färg")]
        public string Color { get; set; }

        [DisplayName("År")]
        public int Year { get; set; }

        [DisplayName("Antal hjul")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Fordonstyp")]
        public VehicleType VehicleType { get; set; }

        public Slot Slot { get; set; }

        [DisplayName("Ägare")]
        public Owner Owner { get; set; }
    }
}