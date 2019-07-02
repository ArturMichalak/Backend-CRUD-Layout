namespace backend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTruckId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Truck_VIN", "dbo.Trucks");
            DropIndex("dbo.Orders", new[] { "Truck_VIN" });
            RenameColumn(table: "dbo.Orders", name: "Truck_VIN", newName: "Truck_Id");
            DropPrimaryKey("dbo.Trucks");
            AddColumn("dbo.Trucks", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Orders", "Truck_Id", c => c.Int());
            AlterColumn("dbo.Trucks", "VIN", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Trucks", "Id");
            CreateIndex("dbo.Orders", "Truck_Id");
            AddForeignKey("dbo.Orders", "Truck_Id", "dbo.Trucks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Truck_Id", "dbo.Trucks");
            DropIndex("dbo.Orders", new[] { "Truck_Id" });
            DropPrimaryKey("dbo.Trucks");
            AlterColumn("dbo.Trucks", "VIN", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "Truck_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Trucks", "Id");
            AddPrimaryKey("dbo.Trucks", "VIN");
            RenameColumn(table: "dbo.Orders", name: "Truck_Id", newName: "Truck_VIN");
            CreateIndex("dbo.Orders", "Truck_VIN");
            AddForeignKey("dbo.Orders", "Truck_VIN", "dbo.Trucks", "VIN");
        }
    }
}
