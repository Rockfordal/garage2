namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Javivillgärnahadatetimenullableiställetförstringtack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slots", "ParkTime", c => c.DateTime());
            AlterColumn("dbo.Slots", "PayedParkTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slots", "PayedParkTime", c => c.String());
            AlterColumn("dbo.Slots", "ParkTime", c => c.String());
        }
    }
}
