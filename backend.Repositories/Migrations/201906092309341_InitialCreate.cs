namespace backend.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Pesel = c.String(),
                        Hiredate = c.String(),
                        AccountNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Customer = c.String(),
                        CustomerAddress = c.String(),
                        CustomerNIP = c.String(),
                        CargoType = c.String(),
                        IsADR = c.Boolean(nullable: false),
                        CargoSize = c.Int(nullable: false),
                        CargoSizeUnit = c.String(),
                        CargoValue = c.Int(nullable: false),
                        Currency = c.String(),
                        TrailerRegistrationNumber = c.String(),
                        TrailerType = c.String(),
                        LoadingId = c.Int(nullable: false),
                        UnloadingId = c.Int(nullable: false),
                        FreightRateValue = c.Int(nullable: false),
                        FreightRateCurrency = c.String(),
                        FreightRateDeadline = c.DateTime(nullable: false),
                        IsExecuted = c.Boolean(nullable: false),
                        Truck_VIN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Trucks", t => t.Truck_VIN)
                .Index(t => t.Truck_VIN);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        VIN = c.String(nullable: false, maxLength: 128),
                        RegistrationNumber = c.String(nullable: false),
                        ServicingDate = c.DateTime(nullable: false),
                        ServicingEndDate = c.DateTime(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        EmissionStandard = c.String(),
                    })
                .PrimaryKey(t => t.VIN);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoutePoints",
                c => new
                    {
                        RoutePointId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        IsLoading = c.Boolean(nullable: false),
                        Route_RouteId = c.Int(),
                    })
                .PrimaryKey(t => t.RoutePointId)
                .ForeignKey("dbo.Routes", t => t.Route_RouteId)
                .Index(t => t.Route_RouteId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RouteId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkingTimeLogs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Driver_DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverId, cascadeDelete: true)
                .Index(t => t.Driver_DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkingTimeLogs", "Driver_DriverId", "dbo.Drivers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RoutePoints", "Route_RouteId", "dbo.Routes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "Truck_VIN", "dbo.Trucks");
            DropIndex("dbo.WorkingTimeLogs", new[] { "Driver_DriverId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RoutePoints", new[] { "Route_RouteId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "Truck_VIN" });
            DropTable("dbo.WorkingTimeLogs");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Routes");
            DropTable("dbo.RoutePoints");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trucks");
            DropTable("dbo.Orders");
            DropTable("dbo.Drivers");
        }
    }
}
