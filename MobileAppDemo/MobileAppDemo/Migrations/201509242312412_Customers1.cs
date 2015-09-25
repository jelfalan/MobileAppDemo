namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Comments", c => c.String());
            DropColumn("dbo.Customers", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Comment", c => c.String());
            DropColumn("dbo.Customers", "Comments");
        }
    }
}
