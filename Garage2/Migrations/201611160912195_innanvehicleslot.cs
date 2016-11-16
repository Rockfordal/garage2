namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innanvehicleslot : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Garages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        NumberOfWheels = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        VehicleType = c.Int(nullable: false),
                        Slot_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Owners", "LastName", c => c.String());
            AlterColumn("dbo.Owners", "FirstName", c => c.String());
            AlterColumn("dbo.Garages", "Name", c => c.String());
        }
    }
}
