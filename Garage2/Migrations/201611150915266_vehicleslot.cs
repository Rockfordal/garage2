namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleslot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "VehicleId", c => c.Int());
            CreateIndex("dbo.Slots", "VehicleId");
            AddForeignKey("dbo.Slots", "VehicleId", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Slots", new[] { "VehicleId" });
            DropColumn("dbo.Slots", "VehicleId");
        }
    }
}
