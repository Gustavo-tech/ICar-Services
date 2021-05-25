using ICar.API.Validations;
using ICar.Data.Converter;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Repositories.Interfaces;
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
        private readonly ICarRepository<UserCar> _carRepository;

        public UserCarController(ICarRepository<UserCar> carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                List<UserCar> carsInDatabase = await _carRepository.GetAllCarsAsync();

                List<dynamic> carsOutput = new();

                foreach (UserCar UserCar in carsInDatabase)
                {
                    carsOutput.Add(new
                    {
                        Plate = UserCar.Plate,
                        Maker = UserCar.Maker,
                        Model = UserCar.Model,
                        MakeDate = UserCar.MakeDate,
                        MakedDate = UserCar.MakedDate,
                        KilometersTraveled = UserCar.KilometersTraveled,
                        Price = UserCar.Price,
                        AcceptsChange = UserCar.AcceptsChange,
                        IpvaIsPaid = UserCar.IpvaIsPaid,
                        IsLicensed = UserCar.IsLicensed,
                        IsArmored = UserCar.IsArmored,
                        Message = UserCar.Message,
                        Color = CarPropertyConverter.ConvertColorToString(UserCar.Color),
                        GasolineType = (CarPropertyConverter.ConvertGasolineTypeToString(UserCar.GasolineType)),
                        City = UserCar.City
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
        public async Task<IActionResult> GetCar([FromRoute] string plate)
        {
            plate = plate.ToUpper();
            if (CarValidator.ValidatePlate(plate))
            {
                try
                {
                    UserCar UserCar = await _carRepository.GetCarByPlateAsync(plate);
                    return Ok(UserCar);
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

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetUserCars([FromRoute] string cpf)
        {
            if (UserValidator.ValidateCpf(cpf))
            {
                try
                {
                    List<UserCar> carsOfThisUser = await _carRepository.GetByIdentificationAsync(cpf);
                    return Ok(carsOfThisUser);
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

        [HttpPost("increase/views/{plate}")]
        public async Task<IActionResult> IncreaseNumberOfViews([FromRoute] string plate)
        {
            if (CarValidator.ValidatePlate(plate))
            {
                try
                {
                    await _carRepository.IncreaseNumberOfViewsAsync(plate);
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

    }
}
