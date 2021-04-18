using ICar.API.ViewModels;
using ICar.Data.Models;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.Validations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private readonly IUserQueries _userQueries;
        private readonly UserValidator _userValidator;

        public UserController(IUserQueries userQueries) {
            _userQueries = userQueries;
            _userValidator = new UserValidator();
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] NewUser newUser) {
            User user = _userQueries.GetUserByEmail(newUser.Email);
            User userToInsert = new User(newUser.Cpf, newUser.Name, newUser.Email, newUser.Password, newUser.City);

            if (user == null) {
                List<InvalidReason> invalidReasons = _userValidator.GetInvalidReasons(userToInsert);

                if (invalidReasons == null) {
                    try {
                        _userQueries.InsertUser(userToInsert);
                        return Ok(new {
                            Cpf = newUser.Cpf,
                            Name = newUser.Name,
                            Email = newUser.Email,
                            City = newUser.City,
                            Message = "User inserted succesffully"
                        });
                    }
                    catch (Exception exception) {

                        return Problem(title: "Some error ocurred while inserting this user", detail: exception.Message);
                    }
                }
                else
                    return BadRequest(new {
                        Invalids = invalidReasons,
                        Message = "This user is invalid"
                    });
            }
            else {
                return Unauthorized(new {
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
