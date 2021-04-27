namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_weight_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.Double());
        }
    }
}
