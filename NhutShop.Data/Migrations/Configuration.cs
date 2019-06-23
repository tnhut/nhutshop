namespace NhutShop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
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
            CreateSlide(context);
            //  This method will be called after migrating to the latest version.
            CreatePage(context);       
        }

        private void CreateUser(NhutShopDbContext context)
        {
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

        private void CreateFooter(NhutShopDbContext context)
        {
            if(context.Footer.Count(x=>x.ID==CommonConstants.DefaultFooterId)==0)
            {
                string content = "";
            }
        }

        private void CreateSlide(NhutShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                     new Slide() {
                                Name = "Slider 1",
                                DisplayOrder = 1,
                                Status = true,
                                Url = "#",
                                Image = "/Assets/client/images/bad.jpg",
                                Content =@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                               <span class=""on-get"">GET NOW</span>"
                                    },
                     new Slide() {
                                Name = "Slider 2",
                                DisplayOrder = 2,
                                Status = true,
                                Url = "#",
                                Image = "/Assets/client/images/bad1.jpg",
                                Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                               < span class=""on-get"">GET NOW</span>"
                                 }
                     
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(NhutShopDbContext context)
        {
            if(context.Pages.Count()==0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name="Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error
                    sit voluptatem accusantium doloremque laudantium,
                    totam rem aperiam, eaque ipsa quae ab illo inventore 
                    veritatis et quasi architecto beatae vitae dicta sunt explicabo.
                    Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit,
                    sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. 
                    Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet,
                    consectetur, adipisci velit, sed quia non numquam eius modi tempora 
                    incidunt ut labore et dolore magnam aliquam quaerat voluptatem. 
                    Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis 
                    suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? 
                    Quis autem vel eum iure reprehenderit qui in ea voluptate velit
                    esse quam nihil molestiae consequatur, vel illum qui dolorem eum 
                    fugiat quo voluptas nulla pariatur?",
                        Status = true
                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                  
                }

            }
        }
    }
}
