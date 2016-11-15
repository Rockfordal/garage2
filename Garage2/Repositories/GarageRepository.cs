using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public class GarageRepository
    {
        public GarageRepository(GarageDb db)
        {
        }



        public void GenerateSlots(Garage garage, GarageDb db)
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            var antal = garage.NumberOfSlots;
            int n = 0;
            string t = "";

            int index = 0;

            List<Slot> tmp = new List<Slot>();

            for (int i = 0; i < antal; i++)
            {
                n += 1;
                if (n > 15)
                {
                    index += 1;
                    n = 1;  
                }

                if(n < 10)
                {
                    t = "0" + n.ToString();
                }
                else
                {
                    t = n.ToString("0");
                }
                var slot = new Slot();
                slot.PID = letters[index].ToString() + t;
                slot.Garage = garage;
                slot.Location = "Skellefteå";
                //db.Slots.Add(slot);
                tmp.Add(slot);
            }
            garage.Slots = tmp;
        }
    }
}