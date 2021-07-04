using ICar.IdentityServer.ViewModels.User;
using ICar.Infrastructure.Database.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICar.IdentityServer.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email);
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect("https://youtube.com");
            }
            else
            {
                return Redirect("https://youtube.com/rico");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(NewUserViewModel viewModel)
        {
            User user = new()
            {
                UserName = viewModel.Name,
                Email = viewModel.Email,
                Cpf = viewModel.Cpf,
                AccountCreationDate = DateTime.Now,
                Role = "client"
            };

            IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("login");
            }
            else
            {
                return View();
            }
        }
    }
}
