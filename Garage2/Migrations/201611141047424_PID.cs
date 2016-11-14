namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "PID", c => c.String());
            AddColumn("dbo.Slots", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slots", "Location");
            DropColumn("dbo.Slots", "PID");
        }
    }
}
