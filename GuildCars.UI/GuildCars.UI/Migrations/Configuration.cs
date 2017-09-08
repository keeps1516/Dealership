namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // have we loaded roles already?
            if (roleManager.RoleExists("admin"))
                return;

            if (roleManager.RoleExists("sales"))
                return;

            // create the admin role
            roleManager.Create(new IdentityRole() { Name = "admin" }); roleManager.Create(new IdentityRole() { Name = "sales" });


            // create the default user
            var admin = new ApplicationUser()
            {
                UserName = "admin@guildcars.com",
                Email = "admin@guildcars.com",
            };

            var sales = new ApplicationUser()
            {
                UserName = "sales@guildcars.com",
                Email = "sales@guildcars.com",
            };

            // create the user with the manager class
            userManager.Create(admin, "adminperson");
            userManager.Create(sales, "salesperson");

            // add the user to the admin role
            userManager.AddToRole(admin.Id, "admin");
            userManager.AddToRole(sales.Id, "sales");
        }
    }
}
