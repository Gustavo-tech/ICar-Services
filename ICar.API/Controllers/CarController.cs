using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Cars;
using ICar.Data.ViewModels.Companies;
using ICar.Data.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarQuery _carQuery;

        public CarController(ICarQuery carQuery)
        {
            _carQuery = carQuery;
        }

        [HttpGet("all")]
        public IActionResult GetCars()
        {
            try
            {
                return Ok(_carQuery.GetAllCars());
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        [HttpGet("plate")]
        public IActionResult GetCar([FromRoute] CarPlate carPlate)
        {
            try
            {
                return Ok(_carQuery.GetCar(carPlate.Plate));
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserCars([FromRoute] UserCpf userCpf)
        {
            try
            {
                return Ok(_carQuery.GetCarsWithCpf(userCpf.Cpf));
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting cars of this user",
                    detail: exception.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCompanyCars([FromBody] CompanyCnpj companyCnpj)
        {
            try
            {
                return Ok(_carQuery.GetCarsWithCnpj(companyCnpj.Cnpj));
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting cars of this user",
                    detail: exception.Message);
            }
        }

        [HttpPost("insert")]
        public IActionResult InsertCar([FromBody] Car newCar)
        {
            CarInSystem carInDatabase = _carQuery.GetCar(newCar.Plate);

            if (carInDatabase == null)
            {
                List<InvalidReason> invalidReasons = CarValidator.ValidateCar(newCar);
                if (invalidReasons == null)
                {
                    try
                    {

                        _carQuery.InsertCar(newCar);
                        return Ok();
                    }
                    catch (Exception e)
                    {
                        return Problem(title: "Some error occurred while inserting this car",
                            detail: e.Message);
                    }
                }

                else
                {
                    return BadRequest(new
                    {
                        Message = "This car is invalid",
                        Reasons = invalidReasons
                    });
                }
            }

            else
            {
                return Conflict(new
                {
                    Message = "A car with this plate already exists"
                });
            }
        }

        [HttpPost("increase/views")]
        public IActionResult IncreaseNumberOfViews([FromBody] CarPlate carPlate)
        {
            try
            {
                _carQuery.IncreaseNumberOfViews(carPlate.Plate);
                return Ok("Number of views updated successfully");
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while updating the number of views",
                    detail: exception.Message);
            }
        }
    }
}
