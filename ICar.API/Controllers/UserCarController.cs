using ICar.Data.Converter;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public UserCarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                List<Car> carsInDatabase = await _carRepository.GetAllCarsAsync();

                List<dynamic> carsOutput = new();

                foreach (Car UserCar in carsInDatabase)
                {
                    carsOutput.Add(new
                    {
                        UserCar.Plate,
                        UserCar.Maker,
                        UserCar.Model,
                        UserCar.MakeDate,
                        UserCar.MakedDate,
                        UserCar.KilometersTraveled,
                        UserCar.Price,
                        UserCar.AcceptsChange,
                        UserCar.IpvaIsPaid,
                        UserCar.IsLicensed,
                        UserCar.IsArmored,
                        UserCar.Message,
                        Color = CarPropertyConverter.ConvertColorToString(UserCar.Color),
                        GasolineType = (CarPropertyConverter.ConvertGasolineTypeToString(UserCar.GasolineType)),
                        UserCar.City
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

        //[HttpGet("plate/{plate}")]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        //public async Task<IActionResult> GetCar([FromRoute] string plate)
        //{
        //    plate = plate.ToUpper();
        //    if (CarValidator.ValidatePlate(plate))
        //    {
        //        try
        //        {
        //            UserCar UserCar = await _carRepository.GetCarByPlateAsync(plate);
        //            return Ok(UserCar);
        //        }
        //        catch (Exception exception)
        //        {
        //            return Problem(title: "Some error happened while getting the cars",
        //                detail: exception.Message);
        //        }
        //    }

        //    return BadRequest(new
        //    {
        //        Message = "This plate is invalid"
        //    });
        //}

        //[HttpGet("cpf/{cpf}")]
        //[Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = "client, admin")]
        //public async Task<IActionResult> GetUserCars([FromRoute] string cpf)
        //{
        //    if (UserValidator.ValidateCpf(cpf))
        //    {
        //        try
        //        {
        //            List<UserCar> carsOfThisUser = await _carRepository.GetByIdentificationAsync(cpf);
        //            return Ok(carsOfThisUser);
        //        }
        //        catch (Exception exception)
        //        {
        //            return Problem(title: "Some error happened while getting cars of this user",
        //                detail: exception.Message);
        //        }
        //    }

        //    return BadRequest(new
        //    {
        //        Message = "This is not a valid CPF"
        //    });
        //}

        //[HttpPost("increase/views/{plate}")]
        //public async Task<IActionResult> IncreaseNumberOfViews([FromRoute] string plate)
        //{
        //    if (CarValidator.ValidatePlate(plate))
        //    {
        //        try
        //        {
        //            await _carRepository.IncreaseNumberOfViewsAsync(plate);
        //            return Ok("Number of views updated successfully");
        //        }
        //        catch (Exception exception)
        //        {
        //            return Problem(title: "Some error happened while updating the number of views",
        //                detail: exception.Message);
        //        }
        //    }

        //    return BadRequest(new
        //    {
        //        Message = "This plate is invalid"
        //    });
        //}

    }
}
