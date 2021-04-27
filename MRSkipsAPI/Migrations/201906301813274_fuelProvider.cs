namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuelProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelRecipts", "Provider", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuelRecipts", "Provider");
        }
    }
}
