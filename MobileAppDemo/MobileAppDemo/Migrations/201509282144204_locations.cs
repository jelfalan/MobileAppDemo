namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Collected = c.Boolean(nullable: false),
                        Dry = c.Boolean(nullable: false),
                        Skipped = c.Boolean(nullable: false),
                        Comment = c.String(),
                        timestamp = c.DateTime(nullable: false),
                        geostamp_lat = c.Single(nullable: false),
                        geostamp_lon = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
