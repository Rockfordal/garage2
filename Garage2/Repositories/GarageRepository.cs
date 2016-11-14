using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public class GarageRepository
    {
        private GarageDb db = new GarageDb();
        
        public GarageRepository()
        {
        }
        
        public bool GenerateSlots(Garage garage)
        {
            var antal = garage.NumberOfSlots;
            for (int i = 0; i < antal; i++)
            {
                var slot = new Slot();
                //slot.PID = 
                db.Slots.Add(slot);
            }
            return true;
        }

    }
}