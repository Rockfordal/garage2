namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleManufactuer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Manufacturer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Manufacturer");
        }
    }
}
