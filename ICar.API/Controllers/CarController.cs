using ICar.API.Validations;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;
using ICar.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
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
                        GasolineType = (CarPropertyConverter.ConvertGasolineTypeToString(car.GasolineType)),
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
        public async Task<IActionResult> GetCar([FromRoute] string plate)
        {
            plate = plate.ToUpper();
            if (CarValidator.ValidatePlate(plate))
            {
                try
                {
                    Car car = await _carRepository.GetCarByPlateAsync(plate);
                    return Ok(car);
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
                    List<Car> carsOfThisUser = await _carRepository.GetCarsByCpfAsync(cpf);
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

        [HttpGet("cnpj/{cnpj}")]
        public async Task<IActionResult> GetCompanyCars([FromRoute] string cnpj)
        {
            if (CompanyValidator.ValidateCnpj(cnpj))
            {
                try
                {
                    List<Car> carsOfThisCompany = await _carRepository.GetCarsByCnpjAsync(cnpj);
                    return Ok(carsOfThisCompany);
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

        [HttpPost("increase/views/{plate}")]
        public async Task<IActionResult>  IncreaseNumberOfViews([FromRoute] string plate)
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
