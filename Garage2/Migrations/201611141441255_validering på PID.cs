namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valideringpåPID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Slots", new[] { "Garage_Id" });
            AlterColumn("dbo.Slots", "PID", c => c.String(maxLength: 10));
            AlterColumn("dbo.Slots", "Garage_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
            CreateIndex("dbo.Slots", "Garage_Id");
            AddForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Slots", new[] { "Garage_Id" });
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
            AlterColumn("dbo.Slots", "Garage_Id", c => c.Int());
            AlterColumn("dbo.Slots", "PID", c => c.String());
            CreateIndex("dbo.Slots", "Garage_Id");
            AddForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages", "Id");
        }
    }
}
