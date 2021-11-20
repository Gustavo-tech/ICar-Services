using ICar.IdentityServer.ViewModels.User;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;

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
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel loginViewModel = new()
            {
                ReturnUrl = returnUrl
            };
            return View(loginViewModel);
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
                    Login newLogin = Infrastructure.Models.Login.GenerateSuccessfulLogin(user);
                    await _loginRepository.AddLogin(newLogin);
                }

                else
                {
                    Login login = Infrastructure.Models.Login.GenerateFailedLogin(user);
                    await _loginRepository.AddLogin(login);
                    return View();
                }
            }

            return Redirect(model.ReturnUrl);
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
                User newUser = new(model.Name, model.Phone, model.Email, "client");
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
