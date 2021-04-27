namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skipreason : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuelProviders",
                c => new
                    {
                        FuelProviderId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FuelProviderId);
            
            AddColumn("dbo.TripSheetDeatails_skip", "WasteTypex", c => c.String());
            AddColumn("dbo.TripSheetDeatails_skip", "Reason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripSheetDeatails_skip", "Reason");
            DropColumn("dbo.TripSheetDeatails_skip", "WasteTypex");
            DropTable("dbo.FuelProviders");
        }
    }
}
