namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class signatureDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripSheetDeatails_skip", "SignName", c => c.String());
            AddColumn("dbo.TripSheetDeatails_skip", "SignMobile", c => c.String());
            AddColumn("dbo.TripSheetDeatails_skip", "SignTel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripSheetDeatails_skip", "SignTel");
            DropColumn("dbo.TripSheetDeatails_skip", "SignMobile");
            DropColumn("dbo.TripSheetDeatails_skip", "SignName");
        }
    }
}
