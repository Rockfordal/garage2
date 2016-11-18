using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Data
{

    public interface ISlotRepository
    {
        bool Park();
        Vehicle UnPark(int id);
        Vehicle GetVehicleByID(int id);
        Slot GetSlotById(int id);
    }

    public class SlotRepository
        //: ISlotRepository
    {
        public GarageDbContext db = new GarageDbContext();

        public SlotRepository()
        { 
        }

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
                    s.Vehicle = null;
                    break;
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