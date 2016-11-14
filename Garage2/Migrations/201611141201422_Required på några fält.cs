namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredpånågrafält : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Garages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Owners", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Owners", "LastName", c => c.String());
            AlterColumn("dbo.Owners", "FirstName", c => c.String());
            AlterColumn("dbo.Garages", "Name", c => c.String());
        }
    }
}
