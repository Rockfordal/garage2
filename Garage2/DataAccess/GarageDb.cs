using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.DataAccess
{
    public class GarageDb : DbContext
    {
        public GarageDb() : base("DefaultConnection")
        { }

        public DbSet<Garage>  Garages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Slot>    Slots { get; set; }
        public DbSet<Owner>   Owners { get; set; }


       protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Slot>()
              .HasOptional<Vehicle>(s => s.Vehicle)
              .WithOptionalDependent(v => v.Slot).Map(p => p.MapKey("VehicleId"));
        }

        // public System.Data.Entity.DbSet<Garage2.Entities.Garage> Garages { get; set; }
    } 
}