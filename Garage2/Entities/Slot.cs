using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [DisplayName("Parkeringstid")]
        public DateTime ParkTime { get; set; }

        [DisplayName("Betald Parkeringstid")]
        public DateTime PayedParkTime { get; set; }

    }
}