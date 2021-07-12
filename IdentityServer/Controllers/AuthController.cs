using ICar.IdentityServer.Token.Contracts;
using ICar.Infrastructure.Database.Models;
using IdentityServer.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ICar.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
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
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Token(string client_id, string secret,
            string grant_type, string code, string redirect_uri)
        {
            User user = new(null,
                HttpContext.User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value,
                HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault().Value,
                null);

            string token = _tokenService.GenerateToken(user);
            byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
            await Response.Body.WriteAsync(tokenBytes, 0, tokenBytes.Length);
            return Redirect(redirect_uri);
        }
    }
}
