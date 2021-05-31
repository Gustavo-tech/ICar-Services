using ICar.API.ViewModels;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.Repositories.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
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
