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
    [Route("[controller]")]
    [ApiController]
    public class CompanyCarController : ControllerBase
    {
        private readonly ICarRepository<CompanyCar> _carRepository;

        public CompanyCarController(ICarRepository<CompanyCar> carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                List<CompanyCar> carsInDatabase = await _carRepository.GetAllCarsAsync();

                List<dynamic> carsOutput = new();

                foreach (CompanyCar CompanyCar in carsInDatabase)
                {
                    carsOutput.Add(new
                    {
                        Plate = CompanyCar.Plate,
                        Maker = CompanyCar.Maker,
                        Model = CompanyCar.Model,
                        MakeDate = CompanyCar.MakeDate,
                        MakedDate = CompanyCar.MakedDate,
                        KilometersTraveled = CompanyCar.KilometersTraveled,
                        Price = CompanyCar.Price,
                        AcceptsChange = CompanyCar.AcceptsChange,
                        IpvaIsPaid = CompanyCar.IpvaIsPaid,
                        IsLicensed = CompanyCar.IsLicensed,
                        IsArmored = CompanyCar.IsArmored,
                        Message = CompanyCar.Message,
                        Color = CarPropertyConverter.ConvertColorToString(CompanyCar.Color),
                        GasolineType = (CarPropertyConverter.ConvertGasolineTypeToString(CompanyCar.GasolineType)),
                        City = CompanyCar.City
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
                    CompanyCar CompanyCar = await _carRepository.GetCarByPlateAsync(plate);
                    return Ok(CompanyCar);
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

        [HttpGet("cnpj/{cnpj}")]
        public async Task<IActionResult> GetCompanyCars([FromRoute] string cnpj)
        {
            if (CompanyValidator.ValidateCnpj(cnpj))
            {
                try
                {
                    List<CompanyCar> carsOfThisCompany = await _carRepository.GetByIdentificationAsync(cnpj);
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
