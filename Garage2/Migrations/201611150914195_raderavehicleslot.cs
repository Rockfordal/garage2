namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bortmedslotvehiclerelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots");
            DropIndex("dbo.Vehicles", new[] { "Slot_Id" });
            DropColumn("dbo.Vehicles", "Slot_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Slot_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "Slot_Id");
            AddForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots", "Id");
        }
    }
}
