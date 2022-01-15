using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Tatyrkova.Eshop.Web.Models.Database
{
    public class DatabaseInit
    {
        public void Initialize(EshopDbContext eshopDbContext)
        {
            eshopDbContext.Database.EnsureCreated();

            if(eshopDbContext.CarouselItems.Count() == 0)
            {
                IList<CarouselItem> carouselItems = GenerateCarouselItems();
                foreach(var cI in carouselItems)
                {
                    eshopDbContext.Add(cI);
                }

                eshopDbContext.SaveChanges();
            }

            if(eshopDbContext.Products.Count() == 0)
            {
                IList<Product> products = GenerateProducts();
                foreach(var product in products)
                {
                    eshopDbContext.Add(product);
                }

                eshopDbContext.SaveChanges();
            }
        }

        public List<CarouselItem> GenerateCarouselItems()
        {
            List<CarouselItem> carouselItems = new List<CarouselItem>();

            CarouselItem ci1 = new CarouselItem()
            {
                ID = 0,
                ImageSource = "/img/UTB_1.jpg",
                ImageAlt = "First Slide"
            };

            CarouselItem ci2 = new CarouselItem()
            {
                ID = 1,
                ImageSource = "/img/UTB_2.jpg",
                ImageAlt = "Second Slide"
            };

            CarouselItem ci3 = new CarouselItem()
            {
                ID = 2,
                ImageSource = "/img/UTB_3.jpg",
                ImageAlt = "Third Slide"
            };

            carouselItems.Add(ci1);
            carouselItems.Add(ci2);
            carouselItems.Add(ci3);

            return carouselItems;

        }

        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            Product p1 = new Product()
            {
                ID = 0,
                Name = "Zmrzlina",
                Description = "Nanuk Misa 100g",
                Price = 20,
                ImageSource = "/img/misa.jpg",
                ImageAlt = "Misa Nanuk",
                Category = "Mrazene potraviny"

            };

            Product p2 = new Product()
            {
                ID = 1,
                Name = "Maslo",
                Description = "Kunin Maslo 500g",
                Price = 65,
                ImageSource = "/img/maslo.jpg",
                ImageAlt = "Misa Nanuk",
                Category = "Mlecne vyrobky"
            };

            Product p3 = new Product()
            {ID = 2,
                Name = "Mleko",
                Description = "Olma mleko plnotucne 5%",
                Price = 18,
                ImageSource = "/img/mleko.png",
                ImageAlt = "Misa Nanuk",
                Category = "Mlecne vyrobky"
            };

            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            return products;

        }

        public void Initialization(EshopDbContext eshopDbContext)

        {

            eshopDbContext.Database.EnsureCreated();



            if (eshopDbContext.CarouselItems.Count() == 0)

            {

                IList<CarouselItem> carouselItems = GenerateCarouselItems();

                eshopDbContext.CarouselItems.AddRange(carouselItems);

                eshopDbContext.SaveChanges();

            }


            /*
            if (eshopDbContext.ProductItems.Count() == 0)

            {

                IList<ProductItem> products = GenerateProducts();

                foreach (var prod in products)

                {

                    eshopDbContext.ProductItems.Add(prod);

                }

                eshopDbContext.SaveChanges();

            }*/

        }
        public async Task EnsureRoleCreated(RoleManager<Role> roleManager)
        {
            string[] roles = Enum.GetNames(typeof(Roles));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new Role(role));
            }
        }

        public async Task EnsureAdminCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "admin",
                Email = "admin@admin.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni"
            };
            string password = "abc";

            User adminInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (adminInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Admin: {error.Code}, {error.Description}");
                    }
                }
            }

        }

        public async Task EnsureManagerCreated(UserManager<User> userManager)
        {
            User user = new User
            {
                UserName = "manager",
                Email = "manager@manager.cz",
                EmailConfirmed = true,
                FirstName = "jmeno",
                LastName = "prijmeni"
            };
            string password = "abc";

            User managerInDatabase = await userManager.FindByNameAsync(user.UserName);

            if (managerInDatabase == null)
            {

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result == IdentityResult.Success)
                {
                    string[] roles = Enum.GetNames(typeof(Roles));
                    foreach (var role in roles)
                    {
                        if (role != Roles.Admin.ToString())
                            await userManager.AddToRoleAsync(user, role);
                    }
                }
                else if (result != null && result.Errors != null && result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        Debug.WriteLine($"Error during Role creation for Manager: {error.Code}, {error.Description}");
                    }
                }
            }

        }
    }
}
