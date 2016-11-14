using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Garage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int NumberOfSlots { get; set; }
    }
}