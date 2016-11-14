using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage2.Entities
{
    public class Owner
    {
        [Required]
        public int Id { get; set; }

        [Required, DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [Required, DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed), DisplayName("Namn")]
        public string FullName
        {
            get
            { 
                return FirstName + " " + LastName;
            }
        }
    }
}