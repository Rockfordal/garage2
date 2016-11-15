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
        
        public void GenerateSlots(Garage garage)
        {
            char[] letters = { 'A', 'B', 'C' };
            var antal = garage.NumberOfSlots;
            int lvl = 0;
            int n = 1;
            string pid = "";
            int Id = db.Slots.Count();
            List<Slot> tmp = new List<Slot>();
            foreach(Slot s in db.Slots)
            {
                if (s.Garage.Id == Id)
                {
                    db.Slots.Remove(s);
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
                slot.Id = Id;
                slot.Location = "Skellefteå";
                //db.Slots.Add(slot);
                tmp.Add(slot);
            }
            garage.Slots = tmp;
        }
    }
}