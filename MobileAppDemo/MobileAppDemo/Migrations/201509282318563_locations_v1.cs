namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations_v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "LocationID", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Locations", "Geostamp_lat", c => c.Single(nullable: false));
            AlterColumn("dbo.Locations", "Geostamp_lon", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "geostamp_lon", c => c.Single(nullable: false));
            AlterColumn("dbo.Locations", "geostamp_lat", c => c.Single(nullable: false));
            AlterColumn("dbo.Locations", "timestamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Locations", "LocationID");
        }
    }
}
