using Tatyrkova.Eshop.Web.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatyrkova.Eshop.Web.Models.Database.Configuration;
using Tatyrkova.Eshop.Web.Models.Identity;

namespace Tatyrkova.Eshop.Web.Models.Database
{
    public class EshopDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<CarouselItem> CarouselItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //DatabaseInit dbInit = new DatabaseInit();
        //Product = dbInit.GenerateProducts();
        //    products = dbInit.GenerateProduct();

        public EshopDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new OrderConfiguration());


            var entityTypes = builder.Model.GetEntityTypes();
            foreach (var entity in entityTypes)
            {
                entity.SetTableName(entity.GetTableName().Replace("AspNet", ""));
            }
        }
    }
}
