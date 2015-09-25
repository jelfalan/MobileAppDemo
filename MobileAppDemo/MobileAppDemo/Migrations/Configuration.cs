namespace MobileAppDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MobileAppDemo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MobileAppDemo.Models.TestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MobileAppDemo.Models.TestDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Note: To update db, run in package manager PM> Update-Database, See:
             // https://msdn.microsoft.com/en-us/data/jj591621
            //http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-3

            context.Templates.AddOrUpdate(
                t => t.type,
                new Template() { type = "T1 template" },
                new Template() { type = "T2 template" },
                new Template() { type = "T3 template" }
                );

            context.Options.AddOrUpdate(
                o => o.name,
                new Option { name = "option 1" },
                new Option { name = "option 2" },
                new Option { name = "option 3" },
                new Option { name = "option 4" }
                );

        }
    }
}
