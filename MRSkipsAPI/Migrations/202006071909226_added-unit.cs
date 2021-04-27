namespace MRSkipsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedunit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelRecipts", "unit", c => c.String());
            AlterColumn("dbo.FuelRecipts", "Rate", c => c.Single());
            AlterColumn("dbo.FuelRecipts", "Amount", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FuelRecipts", "Amount", c => c.Single(nullable: false));
            AlterColumn("dbo.FuelRecipts", "Rate", c => c.Single(nullable: false));
            DropColumn("dbo.FuelRecipts", "unit");
        }
    }
}
