using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatyrkova.Eshop.Web.Areas.Admin.Controllers;
using Tatyrkova.Eshop.Web.Models.ApplicationServices.Abstraction;
using Tatyrkova.Eshop.Web.Models.Identity;
using Tatyrkova.Eshop.Web.Models.ViewModels;

namespace Tatyrkova.Eshop.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        ISecurityApplicationService security;

        public AccountController(ISecurityApplicationService security)
        {
            this.security = security;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                //register
                string[] errors = await security.Register(registerVM, Roles.Customer);
                if (errors == null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        UserName = registerVM.UserName,
                        Password = registerVM.Password,
                    };
                    return await Login(loginVM);
                }
            }
            return View(registerVM);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                loginVM.LoignFailed = !await security.Login(loginVM);
                if (loginVM.LoignFailed == false)
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""), new { area = "" });
                }
                //login
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await security.Logout();
            return RedirectToAction(nameof(Login));
        }

    }
}
