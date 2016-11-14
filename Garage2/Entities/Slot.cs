using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Slot
    {
        public int Id { get; set; }
        public string PID { get; set; }
        public string Location { get; set; }

        public virtual Garage Garage { get; set; }
    }
}