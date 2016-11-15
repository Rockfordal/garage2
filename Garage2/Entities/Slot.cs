using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }

        [MinLength(1), MaxLength(10), DisplayName("ID-nummer")]
        public string PID { get; set; }

        [DisplayName("Plats")]
        public string Location { get; set; }

        [Required, DisplayName("Garage")]
        public Garage Garage { get; set; }

        [DisplayName("Fordon")]
        public Vehicle Vehicle { get; set; }
    }
}