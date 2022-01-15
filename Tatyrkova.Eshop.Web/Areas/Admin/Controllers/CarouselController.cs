﻿using Tatyrkova.Eshop.Web.Models.Database;
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
    public class CarouselController : Controller
    {
        readonly EshopDbContext eshopDbContext;
        IWebHostEnvironment env;

        public CarouselController(EshopDbContext eshopDB, IWebHostEnvironment env)
        {
            eshopDbContext = eshopDB;
            this.env = env;
        }
        public IActionResult Select()
        {
            IList<CarouselItem> carouselItems = eshopDbContext.CarouselItems.ToList();

            return View(carouselItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarouselItem carouselItem)
        {
            if (carouselItem != null && carouselItem.Image != null)
            {
                FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/CarouselItems", "image");
                carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);

                ModelState.Clear();
                TryValidateModel(carouselItem);
                if (ModelState.IsValid)
                {
                    if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false)
                    {
                        eshopDbContext.CarouselItems.Add(carouselItem);

                        await eshopDbContext.SaveChangesAsync();

                        return RedirectToAction(nameof(CarouselController.Select));
                    }

                }
            }

            return View(carouselItem);

        }

        public IActionResult Edit(int ID)
        {
            CarouselItem cIFromDB = eshopDbContext.CarouselItems.FirstOrDefault(cI => cI.ID == ID);

            if (cIFromDB != null)
            {
                return View(cIFromDB);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarouselItem carouselItem)
        {

            CarouselItem cIFromDB = eshopDbContext.CarouselItems.FirstOrDefault(cI => cI.ID == carouselItem.ID);

            if (cIFromDB != null)
            {
                if (carouselItem != null && carouselItem.Image != null)
                {
                    FileUpload fileUpload = new FileUpload(env.WebRootPath, "img/CarouselItems", "image");
                    carouselItem.ImageSource = await fileUpload.FileUploadAsync(carouselItem.Image);

                    if (String.IsNullOrWhiteSpace(carouselItem.ImageSource) == false)
                    {
                        cIFromDB.ImageSource = carouselItem.ImageSource;

                    }
                }
                cIFromDB.ImageAlt = carouselItem.ImageAlt;
                await eshopDbContext.SaveChangesAsync();

                return RedirectToAction(nameof(CarouselController.Select));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int ID)
        {
            DbSet<CarouselItem> carouselItems = eshopDbContext.CarouselItems;

            CarouselItem carouselItem = carouselItems.Where(carouselItem => carouselItem.ID == ID).FirstOrDefault();

            if (carouselItem != null)
            {
                carouselItems.Remove(carouselItem);

                await eshopDbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(CarouselController.Select));
        }



    }
}
