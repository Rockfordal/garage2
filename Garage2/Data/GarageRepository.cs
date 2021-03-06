﻿using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Garage2.Data
{
    public class GarageRepository
    {
        public GarageDbContext db = new GarageDbContext();
        public PIDGenerator PIDGen = new PIDGenerator();

        public GarageRepository()
        {
        }

        /// <summary>
        /// Returns all existing slots in the database
        /// </summary>
        public List<Slot> GetGarageSlots()
        {
            return db.Slots.ToList();
        }

        /// <summary>
        /// Return a garage via id input
        /// </summary>
        /// <param name="id"></param>
        public Garage GetGarageByID(int id)
        {
            return db.Garages.Find(id);
        }

        /// <summary>
        /// Returns a garage with assoiciated slots
        /// </summary>
        /// <param name="id"></param>
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
        public List<Slot> GetSlotsInGarage(Garage g)
        {
            return db.Slots.Where(s => s.Garage.Id == g.Id).OrderBy(s => s.PID).ToList();
        
        }
        /// <summary>
        /// Returns all slots associated to the garage via garage id
        /// </summary>
        /// <param name="id"></param>
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
            PIDGen.GenerateSlots(g, db);
            db.Garages.Add(g);
            db.SaveChanges();
        }

        /// <summary>
        /// Returns a garage or null
        /// </summary>
        public Garage GimmeAGarage()
        {
            return db.Garages.FirstOrDefault();
        }

        /// <summary>
        /// Returns all garages
        /// </summary>
        public List<Garage> GetAllGarages()
        {
            return db.Garages.ToList();
        }

        
    }
}