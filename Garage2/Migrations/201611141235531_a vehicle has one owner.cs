namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avehiclehasoneowner : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Owners", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Owners", new[] { "Vehicle_Id" });
            AddColumn("dbo.Vehicles", "Owner_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "Owner_Id");
            AddForeignKey("dbo.Vehicles", "Owner_Id", "dbo.Owners", "Id");
            //DropColumn("dbo.Owners", "Vehicle_Id");
            DropColumn("dbo.Vehicles", "VehicleType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "VehicleType", c => c.Int(nullable: false));
            //AddColumn("dbo.Owners", "Vehicle_Id", c => c.Int());
            DropForeignKey("dbo.Vehicles", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.Vehicles", new[] { "Owner_Id" });
            DropColumn("dbo.Vehicles", "Owner_Id");
            //CreateIndex("dbo.Owners", "Vehicle_Id");
            AddForeignKey("dbo.Owners", "Vehicle_Id", "dbo.Vehicles", "Id");
        }
    }
}
