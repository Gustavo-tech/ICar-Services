using ICar.API.Validations;
using ICar.Data.Models.Entities;

using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
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
        private readonly IUserQueries _userQueries;

        public UserController(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            User user = _userQueries.GetUserByEmail(newUser.Email);

            if (user == null)
            {
                List<InvalidReason> invalidReasons = UserValidator.GetInvalidReasonsForInsert(newUser);

                if (invalidReasons == null)
                {
                    try
                    {
                        await _userQueries.InsertUser(newUser);
                        return Ok(new
                        {
                            Cpf = newUser.Cpf,
                            Name = newUser.Name,
                            Email = newUser.Email,
                            City = newUser.City,
                            Message = "User inserted succesffully"
                        });
                    }
                    catch (Exception exception)
                    {

                        return Problem(title: "Some error ocurred while inserting this user", detail: exception.Message);
                    }
                }
                else
                    return BadRequest(new
                    {
                        Invalids = invalidReasons,
                        Message = "This user is invalid"
                    });
            }
            else
            {
                return Unauthorized(new
                {
                    Cpf = newUser.Cpf,
                    Name = newUser.Name,
                    Email = newUser.Email,
                    City = newUser.City,
                    Message = "This user already exists"
                });
            }
        }
    }
}
