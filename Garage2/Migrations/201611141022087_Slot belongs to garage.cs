namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slotbelongstogarage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slots", "Garage_Id", c => c.Int());
            CreateIndex("dbo.Slots", "Garage_Id");
            AddForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Slots", new[] { "Garage_Id" });
            DropColumn("dbo.Slots", "Garage_Id");
        }
    }
}
