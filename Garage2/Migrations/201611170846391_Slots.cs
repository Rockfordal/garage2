namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slots : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "ParkTime", c => c.DateTime());
            AddColumn("dbo.Slots", "PayedParkTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slots", "PayedParkTime");
            DropColumn("dbo.Slots", "ParkTime");
        }
    }
}
