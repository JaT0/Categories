using Tatyrkova.Eshop.Web.Models.Database;
using Tatyrkova.Eshop.Web.Models.Entity;
using Tatyrkova.Eshop.Web.Models.Identity;
using Tatyrkova.Eshop.Web.Models.Implementation;
using Tatyrkova.Eshop.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin)+ ", " + nameof(Roles.Manager))]
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;
        public CarouselController(EshopDbContext eshopDb, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDb;
            this.env = env;
        }

        public IActionResult Select()
        {
            IndexViewModel indexVM = new IndexViewModel();
            indexVM.CarouselItems = eshopDbContext.CarouselItems.ToList();

            return View(indexVM);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarouselItem carouselItem)
        {

            if (carouselItem.Image != null)
            {
                FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/Carousels", "image");
                carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);
                
                ModelState.Clear();
                TryValidateModel(carouselItem);
                if (ModelState.IsValid)
                {
                        eshopDbContext.CarouselItems.Add(carouselItem);

                        eshopDbContext.SaveChanges();

                        return RedirectToAction(nameof(CarouselController.Select));
                }
            }

            return View(carouselItem);

        }

        public IActionResult Edit(int ID)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.Where(cItem => cItem.ID == ID).FirstOrDefault();
            if (carouselItem != null)
            {
                return View(carouselItem);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CarouselItem carouselItem)
        {

            CarouselItem carItem = eshopDbContext.CarouselItems
                                            .Where(cItem => cItem.ID == carouselItem.ID)
                                            .FirstOrDefault();

            if (carItem != null)
            {
                if (carouselItem.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/Carousels", "image");
                    carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);

                    if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false)
                    {
                        carItem.ImageSource = carouselItem.ImageSource;
                    }
                }
                else
                {
                    carouselItem.ImageSource = "-our little hack-";
                }
                ModelState.Clear();
                TryValidateModel(carouselItem);
                if (ModelState.IsValid)
                {
                    carItem.ImageAlt = carouselItem.ImageAlt;
                }
                
                eshopDbContext.SaveChanges();
                return RedirectToAction(nameof(CarouselController.Select));
            }
            return View(carouselItem);
        }

        public IActionResult Delete(int ID)
        {
            CarouselItem carouselItem = eshopDbContext.CarouselItems.Where(cItem => cItem.ID == ID).FirstOrDefault();
            if (carouselItem != null)
            {
                eshopDbContext.CarouselItems.Remove(carouselItem);

                eshopDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(CarouselController.Select));
        }
    }
}
