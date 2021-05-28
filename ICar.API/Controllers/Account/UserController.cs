using ICar.API.ViewModels;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.System;
using ICar.Data.Repositories.Interfaces.Accounts;
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
                        User userToInsert = new User(newUser.Cpf, newUser.Name, newUser.Email,
                            newUser.Password, DateTime.Now, null, new City(newUser.City), "client");


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
    }
}
