namespace BugTrackerV2.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerV2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BugTrackerV2.Models.ApplicationDbContext";
        }

        protected override void Seed(BugTrackerV2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.Add(new IdentityRole { Name = "Admin" });
            context.Roles.Add(new IdentityRole { Name = "Manager" });
            context.Roles.Add(new IdentityRole { Name = "Developer" });
            context.Roles.Add(new IdentityRole { Name = "Submitter" });

            context.SaveChanges();
        }
    }
}
