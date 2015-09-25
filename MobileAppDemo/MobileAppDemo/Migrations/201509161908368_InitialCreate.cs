namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.Options");
            DropTable("dbo.Templates");
            DropTable("dbo.Customers");
        }
    }
}
