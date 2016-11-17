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
        public GarageDb db = new GarageDb();

        public GarageRepository()
        {
        }

        /// <summary>
        /// Returns all existing slots in the database
        /// </summary>
        /// <returns></returns>
        public List<Slot> GetGarageSlots()
        {
            return db.Slots.ToList();
        }

        /// <summary>
        /// Return a garage via id input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Garage GetGarageByID(int id)
        {
            return db.Garages.Find(id);
        }

        /// <summary>
        /// Returns a garage with assoiciated slots
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Garage GetGarageByIdWithSlots(int id)
        {
            Garage g = GetGarageByID(id);
            g.Slots = GetSlotsInGarage(g); //KILL ME
            return g;
        }

        /// <summary>
        /// Returns all slots associated to the garage
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public List<Slot> GetSlotsInGarage(Garage g)
        {
            return db.Slots.Where(s => s.Garage.Id == g.Id).OrderBy(s => s.PID).ToList();
        
        }
        /// <summary>
        /// Returns all slots associated to the garage via garage id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Slot> GetSlotsInGarage(int id)
        {
            return db.Slots.Where(s => s.Garage.Id == id).OrderBy(s => s.PID).ToList();
        }

        /// <summary>
        /// Uses input id to delete a garage with the same id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGarage(int id)
        {
            var g = GetGarageByID(id);
            db.Garages.Remove(g);
            db.SaveChanges();
        }

        /// <summary>
        /// Generates slots and adds new Garage to database
        /// </summary>
        /// <param name="g"></param>
        public void CreateGarage(Garage g)
        {
            db.Entry(g).State = EntityState.Modified;
            GenerateSlots(g);
            db.Garages.Add(g);
            db.SaveChanges();
        }

        /// <summary>
        /// Returns a garage or null
        /// </summary>
        /// <returns></returns>
        public Garage GimmeAGarage()
        {
            return db.Garages.FirstOrDefault();
        }

        /// <summary>
        /// Returns all garages
        /// </summary>
        /// <returns></returns>
        public List<Garage> GetAllGarages()
        {
            return db.Garages.ToList();
        }

        /// <summary>
        /// Generates slots with the format: A letter and 2 digits. eg: A08
        /// </summary>
        /// <param name="garage"></param>
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