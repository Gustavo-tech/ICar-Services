using IdentityServer.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
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
                Password = "232132",
                Role = "admin"
            };

            await _signInManager.SignInAsync(user, false);
            return Redirect("https://youtube.com");
        }
    }
}
