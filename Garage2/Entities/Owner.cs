using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName
        {
            get
            { 
                return FirstName + " " + LastName;
            }
        }
    }
}