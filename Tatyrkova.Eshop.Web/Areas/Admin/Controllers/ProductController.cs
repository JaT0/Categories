using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;

        public ProductController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }
        public IActionResult Select()
        {
            IList<Product> products = eshopDbContext.Products.ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product != null && product.Image != null)
            {
                FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/Products", "image");
                product.ImageSource = await fileUpload.FileUploadAsync(product.Image);

                if (String.IsNullOrWhiteSpace(product.ImageSource) == false)
                {
                    eshopDbContext.Products.Add(product);

                    await eshopDbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(ProductController.Select));
                }
            }

            return View(product);

        }

        public IActionResult Edit(int ID)
        {
            Product productFromDB = eshopDbContext.Products.FirstOrDefault(cI => cI.ID == ID);

            if (productFromDB != null)
            {
                return View(productFromDB);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {

            Product productFromDB = eshopDbContext.Products.FirstOrDefault(cI => cI.ID == product.ID);

            if (productFromDB != null)
            {
                if (product != null && product.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/Products", "image");
                    product.ImageSource = await fileUpload.FileUploadAsync(product.Image);

                    if (String.IsNullOrWhiteSpace(product.ImageSource) == false)
                    {
                        productFromDB.ImageSource = product.ImageSource;

                    }
                }
                productFromDB.ImageAlt = product.ImageAlt;
                await eshopDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(ProductController.Select));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int ID)
        {
            DbSet<Product> products = eshopDbContext.Products;

            Product product = products.Where(carouselItem => carouselItem.ID == ID).FirstOrDefault();

            if (product != null)
            {
                products.Remove(product);

                await eshopDbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ProductController.Select));
        }
    }
}
