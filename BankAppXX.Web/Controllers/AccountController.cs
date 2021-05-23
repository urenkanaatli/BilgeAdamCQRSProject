using BankAppXX.Web.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppXX.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");

        }

        public IActionResult AccessDenied()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            


            ApplicationUser user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ViewBag.error = "Email yada şifren hatalı";
                return View();
            }


            bool passwordResult = await userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordResult)
            {
                ViewBag.error = "Email yada şifren hatalı";
                return View();

            }

            await signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");
        }
    }
}
