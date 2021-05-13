using ICar.API.Validations;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;
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
                List<Car> carsInDatabase = _carQuery.GetAllCars();

                List<dynamic> carsOutput = new List<dynamic>();

                foreach (Car car in carsInDatabase)
                {
                    carsOutput.Add(new
                    {
                        Plate = car.Plate,
                        Maker = car.Maker,
                        Model = car.Model,
                        MakeDate = car.MakeDate,
                        MakedDate = car.MakedDate,
                        KilometersTraveled = car.KilometersTraveled,
                        Price = car.Price,
                        AcceptsChange = car.AcceptsChange,
                        IpvaIsPaid = car.IpvaIsPaid,
                        IsLicensed = car.IsLicensed,
                        IsArmored = car.IsArmored,
                        Message = car.Message,
                        Color = CarPropertyConverter.ConvertColorToString(car.Color),
                        GasolineType = CompleteGasolineType(CarPropertyConverter.ConvertGasolineTypeToString(car.GasolineType)),
                        City = car.City
                    });
                }

                return Ok(carsOutput);
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        [HttpGet("plate/{plate}")]
        public IActionResult GetCar([FromRoute] string plate)
        {
            plate = plate.ToUpper();
            if (CarValidator.ValidatePlate(plate))
            {
                try
                {
                    return Ok(_carQuery.GetCar(plate));
                }
                catch (Exception exception)
                {
                    return Problem(title: "Some error happened while getting the cars",
                        detail: exception.Message);
                }
            }

            return BadRequest(new
            {
                Message = "This plate is invalid"
            });
        }

        [HttpGet("cpf")]
        public IActionResult GetUserCars([FromRoute] UserCpf userCpf)
        {
            if (UserValidator.ValidateCpf(userCpf.Cpf))
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

            return BadRequest(new
            {
                Message = "This is not a valid CPF"
            });
        }

        [HttpGet("cnpj")]
        public IActionResult GetCompanyCars([FromBody] CompanyCnpj companyCnpj)
        {
            if (CompanyValidator.ValidateCnpj(companyCnpj.Cnpj))
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

            return BadRequest(new
            {
                Message = "This is not a valid CNPJ"
            });
        }

        [HttpPost("insert")]
        public IActionResult InsertCar([FromBody] NewCar newCar)
        {
            Car carInDatabase = _carQuery.GetCar(newCar.Plate);

            if (carInDatabase == null)
            {
                List<InvalidReason> invalidReasons = CarValidator.ValidateNewCar(newCar);
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
            if (CarValidator.ValidatePlate(carPlate.Plate))
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

            return BadRequest(new
            {
                Message = "This plate is invalid"
            });
        }

        private string CompleteGasolineType(string gasolineType)
        {
            gasolineType = gasolineType.ToLower();

            switch (gasolineType)
            {
                case "die":
                    return "Diesel";
                case "ele":
                    return "Eletric";
                case "gad":
                    return "Gasoline and Diesel";
                default:
                    return "Gasoline";
            }
        }
    }
}
