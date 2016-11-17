using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Garage2.Models
{
    public class EditVehicleVM
    {
        public int Id { get; set; }

        [DisplayName("Regnummer")]
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

        [DisplayName("Ägare")]
        public Owner Owner { get; set; }

        // public int SlotId { get; set; }

        [DisplayName("Parkering")]
        public IEnumerable<SelectListItem> Slots { get; set; }
        // public virtual Slot Slot { get; set; }

    }

}