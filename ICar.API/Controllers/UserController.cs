using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueries _userQueries;
        private readonly UserValidator _userValidator;

        public UserController(IUserQueries userQueries)
        {
            _userQueries = userQueries;
            _userValidator = new UserValidator();
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            UserInSystem user = _userQueries.GetUserByEmail(newUser.Email);

            if (user == null)
            {
                List<InvalidReason> invalidReasons = _userValidator.GetInvalidReasonsForInsert(newUser);

                if (invalidReasons == null)
                {
                    try
                    {
                        _userQueries.InsertUser(newUser);
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
