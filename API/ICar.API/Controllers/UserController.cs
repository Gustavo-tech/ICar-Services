using ICar.API.Generators;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetUsersAsync();
                dynamic[] output = UserOutputFactory.GenerateUserOutput(users);
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("info/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserInformation([FromRoute] string email)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                return Ok(new
                {
                    user.Email,
                    user.UserName,
                    user.Cpf,
                    user.AccountCreationDate
                });
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("logins/{email}")]
        [Authorize]
        public async Task<IActionResult> GetLogins([FromRoute] string email)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                return Ok(user.Logins);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
