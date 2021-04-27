namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.HelperActualDuties", newName: "ActualDutyHelper");
            //RenameTable(name: "dbo.HelperTripSheetDaetails", newName: "TripSheetDaetailHelper");
            //RenameTable(name: "dbo.RouteHelpers", newName: "RouteHelper");
            //RenameTable(name: "dbo.TripSheetHelpers", newName: "TripSheetHelper");
            //DropForeignKey("dbo.Shifts", "ActualDutyId", "dbo.ActualDuties");
            //DropIndex("dbo.Shifts", new[] { "ActualDutyId" });
            /*RenameColumn(table: "dbo.ActualDutyHelper", name: "Helper_HelperId", newName: "HelperId");
            RenameColumn(table: "dbo.ActualDutyHelper", name: "ActualDuty_ActualDutyId", newName: "ActualDutyId");
            RenameColumn(table: "dbo.Shifts", name: "ActualDutyId", newName: "ActualDuty_ActualDutyId");
            RenameColumn(table: "dbo.TripSheetDaetailHelper", name: "Helper_HelperId", newName: "HelperId");
            RenameColumn(table: "dbo.TripSheetDaetailHelper", name: "TripSheetDaetails_TripSheetDaetailsId", newName: "TripSheetDaetailsId");
            RenameColumn(table: "dbo.RouteHelper", name: "Route_RouteId", newName: "RouteId");
            RenameColumn(table: "dbo.RouteHelper", name: "Helper_HelperId", newName: "HelperId");
            RenameColumn(table: "dbo.TripSheetHelper", name: "TripSheet_TripSheetId", newName: "TripSheetId");
            RenameColumn(table: "dbo.TripSheetHelper", name: "Helper_HelperId", newName: "HelperId");
            RenameIndex(table: "dbo.RouteHelper", name: "IX_Route_RouteId", newName: "IX_RouteId");
            RenameIndex(table: "dbo.RouteHelper", name: "IX_Helper_HelperId", newName: "IX_HelperId");
            RenameIndex(table: "dbo.TripSheetHelper", name: "IX_TripSheet_TripSheetId", newName: "IX_TripSheetId");
            RenameIndex(table: "dbo.TripSheetHelper", name: "IX_Helper_HelperId", newName: "IX_HelperId");
            RenameIndex(table: "dbo.TripSheetDaetailHelper", name: "IX_TripSheetDaetails_TripSheetDaetailsId", newName: "IX_TripSheetDaetailsId");
            RenameIndex(table: "dbo.TripSheetDaetailHelper", name: "IX_Helper_HelperId", newName: "IX_HelperId");
            RenameIndex(table: "dbo.ActualDutyHelper", name: "IX_ActualDuty_ActualDutyId", newName: "IX_ActualDutyId");
            RenameIndex(table: "dbo.ActualDutyHelper", name: "IX_Helper_HelperId", newName: "IX_HelperId");
            */
            //DropPrimaryKey("dbo.ActualDutyHelper");
            //DropPrimaryKey("dbo.TripSheetDaetailHelper");
            /*CreateTable(
                "dbo.FuelRecipts",
                c => new
                    {
                        FuelReciptId = c.Int(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        Amount = c.Single(nullable: false),
                        Qty = c.Single(nullable: false),
                        ReciptDate = c.DateTime(nullable: false),
                        DriverId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        ImgRecipt = c.String(),
                    })
                .PrimaryKey(t => t.FuelReciptId)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleId);
            
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
            */
            //DropColumn("dbo.Shifts", "ActualDutyId");
            //AddPrimaryKey("dbo.ActualDutyHelper", new[] { "ActualDutyId", "HelperId" });
            //AddPrimaryKey("dbo.TripSheetDaetailHelper", new[] { "TripSheetDaetailsId", "HelperId" });
            //CreateIndex("dbo.Shifts", "ActualDuty_ActualDutyId");
            //AddForeignKey("dbo.Shifts", "ActualDuty_ActualDutyId", "dbo.ActualDuties", "ActualDutyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "ActualDuty_ActualDutyId", "dbo.ActualDuties");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FuelRecipts", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.FuelRecipts", "DriverId", "dbo.Drivers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FuelRecipts", new[] { "VehicleId" });
            DropIndex("dbo.FuelRecipts", new[] { "DriverId" });
            DropIndex("dbo.Shifts", new[] { "ActualDuty_ActualDutyId" });
            DropPrimaryKey("dbo.TripSheetDaetailHelper");
            DropPrimaryKey("dbo.ActualDutyHelper");
            AlterColumn("dbo.Shifts", "ActualDuty_ActualDutyId", c => c.Int(nullable: false));
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FuelRecipts");
            AddPrimaryKey("dbo.TripSheetDaetailHelper", new[] { "Helper_HelperId", "TripSheetDaetails_TripSheetDaetailsId" });
            AddPrimaryKey("dbo.ActualDutyHelper", new[] { "Helper_HelperId", "ActualDuty_ActualDutyId" });
            RenameIndex(table: "dbo.ActualDutyHelper", name: "IX_HelperId", newName: "IX_Helper_HelperId");
            RenameIndex(table: "dbo.ActualDutyHelper", name: "IX_ActualDutyId", newName: "IX_ActualDuty_ActualDutyId");
            RenameIndex(table: "dbo.TripSheetDaetailHelper", name: "IX_HelperId", newName: "IX_Helper_HelperId");
            RenameIndex(table: "dbo.TripSheetDaetailHelper", name: "IX_TripSheetDaetailsId", newName: "IX_TripSheetDaetails_TripSheetDaetailsId");
            RenameIndex(table: "dbo.TripSheetHelper", name: "IX_HelperId", newName: "IX_Helper_HelperId");
            RenameIndex(table: "dbo.TripSheetHelper", name: "IX_TripSheetId", newName: "IX_TripSheet_TripSheetId");
            RenameIndex(table: "dbo.RouteHelper", name: "IX_HelperId", newName: "IX_Helper_HelperId");
            RenameIndex(table: "dbo.RouteHelper", name: "IX_RouteId", newName: "IX_Route_RouteId");
            RenameColumn(table: "dbo.TripSheetHelper", name: "HelperId", newName: "Helper_HelperId");
            RenameColumn(table: "dbo.TripSheetHelper", name: "TripSheetId", newName: "TripSheet_TripSheetId");
            RenameColumn(table: "dbo.RouteHelper", name: "HelperId", newName: "Helper_HelperId");
            RenameColumn(table: "dbo.RouteHelper", name: "RouteId", newName: "Route_RouteId");
            RenameColumn(table: "dbo.TripSheetDaetailHelper", name: "TripSheetDaetailsId", newName: "TripSheetDaetails_TripSheetDaetailsId");
            RenameColumn(table: "dbo.TripSheetDaetailHelper", name: "HelperId", newName: "Helper_HelperId");
            RenameColumn(table: "dbo.Shifts", name: "ActualDuty_ActualDutyId", newName: "ActualDutyId");
            RenameColumn(table: "dbo.ActualDutyHelper", name: "ActualDutyId", newName: "ActualDuty_ActualDutyId");
            RenameColumn(table: "dbo.ActualDutyHelper", name: "HelperId", newName: "Helper_HelperId");
            CreateIndex("dbo.Shifts", "ActualDutyId");
            AddForeignKey("dbo.Shifts", "ActualDutyId", "dbo.ActualDuties", "ActualDutyId", cascadeDelete: true);
            RenameTable(name: "dbo.TripSheetHelper", newName: "TripSheetHelpers");
            RenameTable(name: "dbo.RouteHelper", newName: "RouteHelpers");
            RenameTable(name: "dbo.TripSheetDaetailHelper", newName: "HelperTripSheetDaetails");
            RenameTable(name: "dbo.ActualDutyHelper", newName: "HelperActualDuties");
        }
    }
}
