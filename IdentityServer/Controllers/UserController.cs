using IdentityServer.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
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
            User user = new User
            {
                Email = "gustavo@gmail.com",
                Cpf = "1232321",
                Name = "Gustavo",
                AccountCreationDate = DateTime.Now,
                Password = "gustavo10&",
                Role = "admin"
            };

            var result = await _signInManager.PasswordSignInAsync(user, user.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect("https://youtube.com");
            }
            else
            {
                return Redirect("https://youtube.com/rico");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser()
        {

        }
    }
}
