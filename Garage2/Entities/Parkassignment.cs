using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Parkassignment
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Fordon")]
        public Vehicle Vehicle { get; set; }
    }
}