namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sync2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "EndShift", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "EndShift", c => c.DateTime(nullable: false));
        }
    }
}
