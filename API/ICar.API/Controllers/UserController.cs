using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICar.API.ViewModels.User;

namespace ICar.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository _baseRepo;

        public UserController(IUserRepository userRepository, IBaseRepository baseRepo)
        {
            _userRepository = userRepository;
            _baseRepo = baseRepo;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetUsersAsync();
                dynamic[] output = users.Select(x => x.GenerateApiOutput()).ToArray();
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

        [HttpPost("message")]
        public async Task<IActionResult> SendMessage([FromRoute] SendMessage sendMessage)
        {
            try
            {
                User from = await _userRepository.GetUserByCpfAsync(sendMessage.CpfFrom);
                User to = await _userRepository.GetUserByCpfAsync(sendMessage.CpfTo);

                if (from is null || to is null)
                {
                    return NotFound(new
                    {
                        Message = "User not found with this CPF"
                    });
                }

                Message message = new(from, to, sendMessage.Text);
                await _baseRepo.AddAsync(message);
                return Ok();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
    }
}
