namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnsVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Owners", "Vehicle_Id", c => c.Int());
            CreateIndex("dbo.Owners", "Vehicle_Id");
            AddForeignKey("dbo.Owners", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Owners", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Owners", new[] { "Vehicle_Id" });
            DropColumn("dbo.Owners", "Vehicle_Id");
        }
    }
}
