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
            char[] letters = { 'A', 'B', 'C' };
            var antal = garage.NumberOfSlots;
            int lvl = 0;
            int n = 1;
            string pid = "";

            List<Slot> tmp = new List<Slot>();
            List<Slot> slots = db.Slots.ToList();
            foreach (Slot s in slots)
            {
                if (s.Garage.Id == garage.Id)
                {
                    db.Entry(slots).State = EntityState.Detached;
                        //Remove(s);
                }
            }
            for (int i = 0; i < antal; i++)
            {
                if (i <= (antal / letters.Length))
                    lvl = 0;
                else if (i > (antal / letters.Length) && i <= (antal / letters.Length) * 2)
                    lvl = 1;
                else
                    lvl = 2;

                pid = letters[lvl].ToString();

                if (n <= (antal / letters.Length))
                    pid += "0" + n;
                if (n > (antal / letters.Length))
                    n = 1;
                else
                    n += 1;


                var slot = new Slot();
                slot.PID = pid;
                slot.Garage = garage;
                slot.Location = "Skellefteå";
                db.Slots.Add(slot);
                tmp.Add(slot);
            }
            garage.Slots = tmp;
        }
    }
}