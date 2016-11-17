using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage2.Entities
{
    public class Owner
    {
        [Key]
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

        [DisplayName("Fordon")]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}