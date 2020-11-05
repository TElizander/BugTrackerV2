namespace BugTrackerV2.Migrations
{
    using BugTrackerV2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.WebSockets;

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

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Developer" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Submitter" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin", FirstName="Jon", LastName="Schmidt" };

                manager.Create(user, ConfigurationManager.AppSettings["DemoPassword"]);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "Manager"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Manager", FirstName = "Jane", LastName = "Scott" };

                manager.Create(user, ConfigurationManager.AppSettings["DemoPassword"]);
                manager.AddToRole(user.Id, "Manager");
            }

            if (!context.Users.Any(u => u.UserName == "Developer"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Developer", FirstName = "Frank", LastName = "Vance" };

                manager.Create(user, ConfigurationManager.AppSettings["DemoPassword"]);
                manager.AddToRole(user.Id, "Developer");
            }

            if (!context.Users.Any(u => u.UserName == "Submitter"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Submitter", FirstName = "Raul", LastName = "Melendrez" };

                manager.Create(user, ConfigurationManager.AppSettings["DemoPassword"]);
                manager.AddToRole(user.Id, "Submitter");
            }


        }
    }
}
