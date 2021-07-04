using ICar.IdentityServer.Models;
using ICar.IdentityServer.ViewModels.User;
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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            User user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            var result = await _signInManager.PasswordSignInAsync(user, user.Password, 
                false, false);

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
            User user = new User
            {
                Email = viewModel.Email,
                Cpf = viewModel.Cpf,
                UserName = viewModel.Name,
                Password = viewModel.Password
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
