namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicletype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "VehicleType");
        }
    }
}
