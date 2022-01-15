using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.ViewModels;

namespace Tatyrkova.Eshop.Web.Controllers
{
    public class ProductsPageController : Controller
    {

        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;

        public ProductsPageController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }
        

        public string OnPost(string categoryName)
        {
            return categoryName;

        }

        public IActionResult Category(int categoryName)
        {
            // DbSet<Product> products = eshopDbContext.Products;

            ProductsPageViewModel productsVM = new ProductsPageViewModel();

            //IList<Product> product = (IList<Product>)eshopDbContext.Products
            //    .Where(product => product.Category == categoryName).ToList();
            //productsVM.Products = product;
            return View(productsVM);
        }
    }

}
