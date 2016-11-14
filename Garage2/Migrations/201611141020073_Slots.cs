namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slots : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "Slot_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "Slot_Id");
            AddForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots");
            DropIndex("dbo.Vehicles", new[] { "Slot_Id" });
            DropColumn("dbo.Vehicles", "Slot_Id");
            DropTable("dbo.Slots");
        }
    }
}
