namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations_v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Timestamp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Timestamp", c => c.DateTime(nullable: false));
        }
    }
}
