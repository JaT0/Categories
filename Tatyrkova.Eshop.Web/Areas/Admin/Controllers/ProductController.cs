using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.Identity;
using Tatyrkova.Eshop.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ProductController : Controller
    {

        readonly EshopDbContext eshopDbContext;
        public ProductController(EshopDbContext eshopDb)
        {
            eshopDbContext = eshopDb;
        }
        public IActionResult Select()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.Products = eshopDbContext.Products.ToList();

            return View(indexVM);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product productItem)
        {
            if (String.IsNullOrWhiteSpace(productItem.Name) == false
                && productItem.Price > 0)
            {
               
                eshopDbContext.Products.Add(productItem);

                eshopDbContext.SaveChanges();

                return RedirectToAction(nameof(ProductController.Select));
            }else
            {
                return View(productItem);
            }
        }

        public IActionResult Edit(int ID)
        {
            Product productItem = eshopDbContext.Products.Where(pItem => pItem.ID == ID).FirstOrDefault();
            if (productItem != null)
            {
                return View(productItem);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Product productItem)
        {
            if (String.IsNullOrWhiteSpace(productItem.Name) == false
               &&  productItem.Price > 0 && String.IsNullOrWhiteSpace(productItem.ImageSource) == false)
            {


                Product proItem = eshopDbContext.Products.Where(pItem => pItem.ID == productItem.ID).FirstOrDefault();
                if (proItem != null)
                {
                    proItem.Name = productItem.Name;
                    proItem.ImageSource = productItem.ImageSource;
                    proItem.Price = productItem.Price;
                    eshopDbContext.SaveChanges();
                    return RedirectToAction(nameof(ProductController.Select));
                }
                
                
                    return NotFound();
                
            }else
            {
                return View(productItem);
            }
        }

            public IActionResult Delete(int ID)
        {
            Product productItem = eshopDbContext.Products.Where(pItem => pItem.ID == ID).FirstOrDefault();
            if(productItem != null)
            {
                eshopDbContext.Products.Remove(productItem);

                eshopDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(ProductController.Select));
        }
    }
}
