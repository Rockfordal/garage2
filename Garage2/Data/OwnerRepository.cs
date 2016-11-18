using Garage2.DataAccess;
using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Garage2.Data
{
    public class OwnerRepository
    {
        public GarageDbContext db = new GarageDbContext();

        public OwnerRepository()
        {
        }

        /// <summary>
        /// Returns one Owner or null
        /// </summary>
        public Owner GimmeOwner()
        {
            return db.Owners.FirstOrDefault();
        }

        /// <summary>
        /// Returns all owners
        /// </summary>
        public List<Owner> GetAllOwners()
        {
            return db.Owners.ToList();
        }

        /// <summary>
        /// Return owner via id input
        /// </summary>
        /// <param name="id"></param>
        public Owner GetOwnerByID(int id)
        {
            return db.Owners.Find(id);
        }

    }
}