namespace NhutShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NhutShop.Data.NhutShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NhutShop.Data.NhutShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NhutShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NhutShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "tnhut",
                Email = "tnhut@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "PeterNhut",
                Address = "93 CMT", 
                Id="12345",          
            };
            
            manager.Create(user, "123459$");
            if(!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tnhut@gmail.com");
            //if (adminUser != null)
          // {
                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
           // }
        }
    }
}
