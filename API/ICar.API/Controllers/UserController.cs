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

        public UserController(IUserRepository userQueries)
        {
            _userRepository = userQueries;
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

        [HttpGet("logins/{cpf}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetLogins([FromRoute] string cpf)
        {
            try
            {
                User user = await _userRepository.GetUserByCpfAsync(cpf);
                return Ok(user.Logins);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        //[HttpPut("update")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<IActionResult> UpdateUser([FromBody] UserViewModel update)
        //{
        //    User user = await _userRepository.GetUserByEmailAsync(update.Email);

        //    if (user != null)
        //    {
        //        if (user.Password == update.Password)
        //        {
        //            try
        //            {
        //                user.Cpf = update.Cpf;
        //                user.Email = update.Email;
        //                user.UserName = update.Name;

        //                await _baseRepository.UpdateAsync(user);
        //                return Ok();
        //            }
        //            catch (Exception)
        //            {
        //                return Problem();
        //            }
        //        }
        //        else
        //            return BadRequest();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpDelete("delete")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<IActionResult> DeleteUser([FromBody] DeleteUserViewModel deleteUser)
        //{
        //    User user = await _userRepository.GetUserByEmailAsync(deleteUser.Email);

        //    if (user != null)
        //    {
        //        if (user.Password == deleteUser.Password)
        //        {
        //            await _baseRepository.DeleteAsync(user);
        //            return Ok(new
        //            {
        //                Message = "User deleted successfully"
        //            });
        //        }
        //        else
        //        {
        //            return BadRequest(new
        //            {
        //                Message = "This email or password is wrong"
        //            });
        //        }
        //    }
        //    else
        //        return NotFound();
        //}
    }
}
