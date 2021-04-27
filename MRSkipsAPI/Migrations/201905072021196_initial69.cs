namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial69 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehicleCheckLists", "ActualDutyId", c => c.Int(nullable: false));
        }
    }
}
