namespace NhutShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
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
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NhutShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NhutShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tnhut",
            //    Email = "tnhut@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "PeterNhut",
            //    Address = "93 CMT", 
            //    Id="12345",          
            //};
            
            //manager.Create(user, "123459$");
            //if(!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tnhut@gmail.com");
           
            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
           
        }

        private void CreateProductCategorySample(NhutShop.Data.NhutShopDbContext context)
        {
            if(context.ProductCategories.Count()==0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {Name= "Tu lanh", Alias="Tu-lanh", Status=true },
                new ProductCategory() {Name= "Điện lạnh", Alias="dien-lanh", Status=true },
                new ProductCategory() {Name= "Vien thong", Alias="vien-thong", Status=true },
                new ProductCategory() {Name= "Mỹ phẩm", Alias="my-pham", Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
           
        }
    }
}
