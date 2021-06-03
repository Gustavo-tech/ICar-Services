﻿using ICar.API.ViewModels;
using ICar.API.ViewModels.User;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
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
        private readonly IBaseRepository _baseRepository;

        public UserController(
            IUserRepository userQueries,
            ICityRepository cityRepository,
            IBaseRepository baseRepository
            )
        {
            _userRepository = userQueries;
            _cityRepository = cityRepository;
            _baseRepository = baseRepository;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<User> users = await _userRepository.GetUsersAsync();
                dynamic[] output = GenerateUserOutput(users);
                return Ok(output);
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

                        await _baseRepository.AddAsync(userToInsert);
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

                        await _baseRepository.UpdateAsync(user);
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
                    await _baseRepository.DeleteAsync(user);
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
                await _baseRepository.AddAsync(insertedCity);
                return insertedCity;
            }

            return city;
        }

        private dynamic GenerateUserOutput(User user)
        {
            return new
            {
                CPF = user.Cpf,
                user.Name,
                user.Email,
                user.AccountCreationDate,
                user.City,
                user.Role,
                user.UserCars,
                user.UserLogins,
                user.UserNews
            };
        }

        private dynamic[] GenerateUserOutput(List<User> users)
        {
            dynamic[] outputs = new dynamic[users.Count];

            for (int i = 0; i <= users.Count - 1; i++)
            {
                outputs[i] = new
                {
                    CPF = users[i].Cpf,
                    users[i].Name,
                    users[i].Email,
                    users[i].AccountCreationDate,
                    City = users[i].City.Name,
                    users[i].Role,
                    users[i].UserCars,
                    UserLogins = GenerateUserLoginOutput(users[i].UserLogins),
                    users[i].UserNews
                };
            }

            return outputs;
        }

        private dynamic[] GenerateUserLoginOutput(List<UserLogin> userLogins)
        {
            dynamic[] output = new dynamic[userLogins.Count];

            for (int i = 0; i < userLogins.Count; i++)
            {
                output[i] = new
                {
                    userLogins[i].Time
                };
            }

            return output;
        }
    }
}