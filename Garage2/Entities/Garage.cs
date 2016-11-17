using Garage2.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        private GarageRepository repo = new GarageRepository();

        public void GenerateSlots(Garage g)
        {
            repo.PIDGen.GenerateSlots(g, repo.db);
        }
    }
}