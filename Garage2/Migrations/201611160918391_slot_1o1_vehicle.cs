namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slot_1o1_vehicle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PID = c.String(maxLength: 10),
                        Location = c.String(),
                        Garage_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Garages", t => t.Garage_Id, cascadeDelete: true)
                .Index(t => t.Garage_Id);
            
            AddColumn("dbo.Vehicles", "Slot_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "Slot_Id");
            AddForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Slot_Id", "dbo.Slots");
            DropForeignKey("dbo.Slots", "Garage_Id", "dbo.Garages");
            DropIndex("dbo.Vehicles", new[] { "Slot_Id" });
            DropIndex("dbo.Slots", new[] { "Garage_Id" });
            DropColumn("dbo.Vehicles", "Slot_Id");
            DropTable("dbo.Slots");
        }
    }
}
