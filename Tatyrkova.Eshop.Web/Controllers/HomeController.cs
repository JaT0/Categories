using Tatyrkova.Eshop.Web.Models;
using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly EshopDbContext eshopDbContext;

        public HomeController(ILogger<HomeController> logger, EshopDbContext eshopDB)
        {
            _logger = logger;
            eshopDbContext = eshopDB;
        }

        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.CarouselItems = eshopDbContext.CarouselItems.ToList();
            indexVM.Products = eshopDbContext.Products.ToList();
            return View(indexVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductsPage()
        {
            ProductsPageViewModel productVM = new ProductsPageViewModel();
            productVM.Products = eshopDbContext.Products.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
