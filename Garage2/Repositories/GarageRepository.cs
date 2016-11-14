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
            char[] letters = { 'A', 'B', 'C' };
            var antal = garage.NumberOfSlots;
            int lvl = 0;
            int n = 1;
            string pid = "";

            for (int i = 0; i < antal; i++)
            {
                if (i < (antal / letters.Length))
                    lvl = 0;
                else if (i > (antal / letters.Length) && i < (antal / letters.Length) * 3)
                    lvl = 1;
                else
                    lvl = 2;

                pid = letters[lvl].ToString();

                if(n<10)
                    pid += "0" + n;
                    

                var slot = new Slot();
                slot.PID = pid;
                slot.Garage = garage;
                slot.Id = i;
                slot.Location = "Skellefteå";
                //garage.Slots.Add(slot);
                db.Slots.Add(slot);
            }
            return true;
        }
    }
}