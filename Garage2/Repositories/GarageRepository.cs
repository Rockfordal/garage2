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
        private GarageDb db = new GarageDb();

        public GarageRepository()
        {
        }

        public List<Slot> GetGarageSots()
        {
            return db.Slots.ToList();
        }

        public Garage GetGarageByID(int id)
        {
            return db.Garages.Find(id);
        }

        public List<Slot> GetSlotsInGarage(Garage g)
        {
            return db.Slots.Where(s => s.Garage.Id == g.Id).OrderBy(s => s.PID).ToList();
        }
        public List<Slot> GetSlotsInGarage(int id)
        {
            return db.Slots.Where(s => s.Garage.Id == id).OrderBy(s => s.PID).ToList();
        }

        public void CreateGarage(Garage g)
        {
            db.Entry(g).State = EntityState.Modified;
            GenerateSlots(g);
            db.Garages.Add(g);
            db.SaveChanges();
        }

        public List<Garage> GetAllGarages()
        {
            return db.Garages.ToList();
        }

        public void GenerateSlots(Garage garage)
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
                    t = "0" + n.ToString();
                else
                    t = n.ToString("0");
                var slot = new Slot();
                slot.PID = letters[index].ToString() + t;
                slot.Garage = garage;
                slot.Location = "Skellefteå";
                db.Slots.Add(slot);
                
                tmp.Add(slot);
            }
            garage.Slots = tmp;
            //db.SaveChanges();
            
        }
    }
}