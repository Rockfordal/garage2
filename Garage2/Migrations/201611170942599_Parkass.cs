namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parkass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parkassignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parkassignments", "Vehicle_Id", "dbo.Vehicles");
            DropIndex("dbo.Parkassignments", new[] { "Vehicle_Id" });
            DropTable("dbo.Parkassignments");
        }
    }
}
