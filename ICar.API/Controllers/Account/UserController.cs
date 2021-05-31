using ICar.API.ViewModels;
using ICar.API.ViewModels.User;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.Repositories.Interfaces.Accounts;
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
        private readonly ICityRepository _cityRepository;

        public UserController(IUserRepository userQueries, ICityRepository cityRepository)
        {
            _userRepository = userQueries;
            _cityRepository = cityRepository;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetUsersAsync();
                return Ok(User);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] NewUserViewModel newUser)
        {
            try
            {
                User user = await _userRepository.GetUserByCpfAsync(newUser.Cpf);

                if (user == null)
                {
                    try
                    {
                        User userToInsert = new(newUser.Cpf, newUser.Name, newUser.Email,
                            newUser.Password, "client");
                        City city = await HandleCityInsertion(newUser.City);
                        userToInsert.City = city;

                        await _userRepository.InsertUserAsync(userToInsert);
                        return Ok(new
                        {
                            CPF = newUser.Cpf,
                            newUser.Name,
                            newUser.Email,
                            newUser.City,
                            Message = "User inserted succesffully"
                        });
                    }
                    catch (Exception)
                    {
                        return Problem();
                    }
                }
                else
                {
                    return Conflict(new
                    {
                        CPF = newUser.Cpf,
                        newUser.Name,
                        newUser.Email,
                        newUser.City,
                        Message = "This user already exists"
                    });
                }
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel updateUser)
        {
            User user = await _userRepository.GetUserByEmailAsync(updateUser.Email);

            if (user != null)
            {
                if (user.Password == updateUser.Password)
                {
                    try
                    {
                        user.Cpf = updateUser.Cpf;
                        user.Email = updateUser.Email;
                        user.Name = updateUser.Name;
                        user.City = await HandleCityInsertion(updateUser.City);

                        await _userRepository.UpdateUserAsync(user);
                        return Ok();
                    }
                    catch (Exception)
                    {
                        return Problem();
                    }
                }
                else
                    return BadRequest();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserViewModel deleteUser)
        {
            User user = await _userRepository.GetUserByEmailAsync(deleteUser.Email);

            if (user != null)
            {
                if (user.Password == deleteUser.Password)
                {
                    await _userRepository.DeleteUserAsync(user);
                    return Ok(new
                    {
                        Message = "User deleted successfully"
                    });
                }
                else
                {
                    return BadRequest(new 
                    {
                        Message = "This email or password is wrong"
                    });
                }
            }
            else
                return NotFound();
        }

        private async Task<City> HandleCityInsertion(string cityName)
        {
            City city = await _cityRepository.GetCityByNameAsync(cityName);

            if (city == null)
            {
                City insertedCity = new(cityName);
                await _cityRepository.InsertCityAsync(insertedCity);
                return insertedCity;
            }

            return city;
        }
    }
}
