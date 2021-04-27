namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {/*
            CreateTable(
                "dbo.TripSheetHelpers",
                c => new
                    {
                        TripSheet_TripSheetId = c.Int(nullable: false),
                        Helper_HelperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripSheet_TripSheetId, t.Helper_HelperId })
                .ForeignKey("dbo.TripSheets", t => t.TripSheet_TripSheetId, cascadeDelete: true)
                .ForeignKey("dbo.Helpers", t => t.Helper_HelperId, cascadeDelete: false)
                .Index(t => t.TripSheet_TripSheetId)
                .Index(t => t.Helper_HelperId);
            
            AddColumn("dbo.Shifts", "TripSheetId", c => c.Int(nullable: false));
            AddColumn("dbo.TripSheets", "ActualDutyDate", c => c.DateTime());
            AddColumn("dbo.VehicleCheckLists", "TripSheetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "TripSheetId");
            CreateIndex("dbo.VehicleCheckLists", "TripSheetId");
            AddForeignKey("dbo.Shifts", "TripSheetId", "dbo.TripSheets", "TripSheetId", cascadeDelete: false);
            AddForeignKey("dbo.VehicleCheckLists", "TripSheetId", "dbo.TripSheets", "TripSheetId", cascadeDelete: false);
        */
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleCheckLists", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.Shifts", "TripSheetId", "dbo.TripSheets");
            DropForeignKey("dbo.TripSheetHelpers", "Helper_HelperId", "dbo.Helpers");
            DropForeignKey("dbo.TripSheetHelpers", "TripSheet_TripSheetId", "dbo.TripSheets");
            DropIndex("dbo.TripSheetHelpers", new[] { "Helper_HelperId" });
            DropIndex("dbo.TripSheetHelpers", new[] { "TripSheet_TripSheetId" });
            DropIndex("dbo.VehicleCheckLists", new[] { "TripSheetId" });
            DropIndex("dbo.Shifts", new[] { "TripSheetId" });
            DropColumn("dbo.VehicleCheckLists", "TripSheetId");
            DropColumn("dbo.TripSheets", "ActualDutyDate");
            DropColumn("dbo.Shifts", "TripSheetId");
            DropTable("dbo.TripSheetHelpers");
        }
    }
}
