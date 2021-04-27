namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_weight_type_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.Single(nullable: false, defaultValueSql: "0"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TripSheetDeatails_skip", "Weight", c => c.Single());
        }
    }
}
