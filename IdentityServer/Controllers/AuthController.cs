using ICar.IdentityServer.ViewModels.User;
using ICar.Infrastructure.Database.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICar.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
            await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(NewUserViewModel model)
        {
            User newUser = new(model.Cpf, model.Name, model.Email, "client");
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
                return RedirectToAction("login");

            return View(model);
        }
    }
}
