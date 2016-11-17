﻿using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public class SlotRepository
    {
        public GarageDb db = new GarageDb();

        public SlotRepository()
        { }

        public bool Park(int id, int v_id)
        {
            Vehicle v = GetVehicleByID(v_id);
            Slot s = GetSlotById(id);

            if (s.Vehicle == null && v.Slot == null)
            {
                s.Vehicle = v;
                //v.Slot = s;
                //s.ParkTime = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public Vehicle UnPark(int id)
        {
            Slot s = GetSlotById(id);
            if (s.Vehicle != null)
            {
                Vehicle v = s.Vehicle;
                s.Vehicle = null;
                v.Slot = null;
                db.SaveChanges();
                return s.Vehicle;
            }
            foreach(var v in db.Vehicles)
            {
                if(v.Slot != null && v.Slot.Id == id)
                {
                    v.Slot = null;
                    
                    return s.Vehicle;
                }
            }
            db.SaveChanges();
            return null;
        }

        public Vehicle GetVehicleByID(int id)
        {
            Vehicle vehicle = db.Vehicles.FirstOrDefault(i => i.Id == id);
            return vehicle;
        }

        public Slot GetSlotById(int id)
        {
            Slot slot = db.Slots.FirstOrDefault(i => i.Id == id);
            return slot;
        }
    }
}