using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Repositories
{
    public class SlotRepository
    {
        private GarageDb db = new GarageDb();

        public SlotRepository()
        { }

        public bool Park(Vehicle v, Slot s)
        {
            if (s.Vehicle == null && v.Slot == null)
            {
                s.Vehicle = v;
                v.Slot = s;
                s.ParkTime = DateTime.Now;
                return true;
            }
            else
                return false;
        }

        public Vehicle UnPark(Slot s)
        {
            if (s.Vehicle != null)
            {
                Vehicle v = s.Vehicle;
                s.Vehicle = null;
                v.Slot = null;
                return s.Vehicle;
            }
            else
                return null;
        }

    }
}