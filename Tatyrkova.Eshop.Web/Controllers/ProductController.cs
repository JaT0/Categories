using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Controllers
{
    public class ProductController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;

        public ProductController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }

        public IActionResult Detail(int ID)
        {
            DbSet<Product> products = eshopDbContext.Products;

            Product product = products.Where(product => product.ID == ID).FirstOrDefault();

            return View(product);
        }
    }
}
