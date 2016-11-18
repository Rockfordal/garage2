using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Data
{

    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetMyParkableVehicles(bool ownage);
        IEnumerable<Vehicle> GetVehicles(bool ownage);
        IEnumerable<Vehicle> Search(string searchString, string typeString);
    }

}