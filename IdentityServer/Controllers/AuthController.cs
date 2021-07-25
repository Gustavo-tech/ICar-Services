using ICar.IdentityServer.ViewModels.User;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICar.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILoginRepository _loginRepository;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, ILoginRepository loginRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    Login newLogin = new()
                    {
                        User = user,
                        Time = DateTime.Now
                    };
                    await _loginRepository.AddLogin(newLogin);
                }
            }

            return Redirect("http://localhost:3000");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(NewUserViewModel model)
        {
            try
            {
                User newUser = new(model.Cpf, model.Name, model.Phone, model.Email, "client");
                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("login");

                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("login");
            }
            catch (Exception)
            {
                return RedirectToAction("login");
            }
        }
    }
}
