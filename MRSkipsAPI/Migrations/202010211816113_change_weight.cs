namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_weight : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.String());
        }
    }
}
