using Garage2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Garage2.DataAccess
{
    public class GarageDb : DbContext
    {
        public GarageDb() : base("DefaultConnection")
        { 
            
        }

        public DbSet<Garage>  Garages  { get; set; }
        public DbSet<Owner>   Owners   { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Slot>    Slots    { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>().ToTable("Slots");

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Slot>()
            //  .HasOptional<Vehicle>(s => s.Vehicle)
            //  .WithOptionalDependent(v => v.Slot).Map(p => p.MapKey("VehicleId"));

            modelBuilder.Entity<Slot>()
                //.HasKey(s => s.Id)
                //.Property(s => s.Id)
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                .HasOptional(s => s.Vehicle).WithOptionalPrincipal(l => l.Slot);
        }


       //public override int SaveChanges()
       //{
       //    try
       //    {
       //        return base.SaveChanges();
       //    }
       //    catch (DbEntityValidationException e)
       //    {
       //        var newException = new FormattedDbEntityValidationException(e);
       //        throw newException;
       //    }
       //}
        // public System.Data.Entity.DbSet<Garage2.Entities.Garage> Garages { get; set; }
    } 
}