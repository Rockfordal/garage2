using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Garage
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Antal Platser")]
        public int NumberOfSlots { get; set; }

        [DisplayName("Parkeringar")]
        public ICollection<Slot> Slots { get; set; }
    }
}