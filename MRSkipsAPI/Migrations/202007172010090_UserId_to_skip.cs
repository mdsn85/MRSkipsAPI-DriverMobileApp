namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId_to_skip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripSheetDeatails_skip", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripSheetDeatails_skip", "UserId");
        }
    }
}
