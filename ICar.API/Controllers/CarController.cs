using ICar.API.Builders;
using ICar.API.Generators;
using ICar.API.OperationsExtension;
using ICar.API.ViewModels.UserCar;
using ICar.Data.Converter;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly CityOperationsExtension _cityOperationsExtension;

        public CarController(ICityRepository cityRepository, ICarRepository carRepository, IBaseRepository baseRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _cityOperationsExtension = new(cityRepository, baseRepository);
        }

        [HttpGet("user/get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserCarsAsync()
        {
            try
            {
                List<Car> carsInDatabase = await _carRepository.GetUserCarsAsync();
                dynamic[] output = CarOutputFactory.GenerateUserCarOutput(carsInDatabase);
                return Ok(output);
            }
            catch (Exception exception)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        [HttpGet("company/get")]
        public async Task<IActionResult> GetCars()
        {
            try
            {
                List<Car> carsInDatabase = await _carRepository.GetCompanyCarsAsync();

                List<dynamic> carsOutput = new();

                foreach (Car CompanyCar in carsInDatabase)
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

        [HttpPost("user/create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCarAsync([FromBody] UserCarViewModel create)
        {
            try
            {
                if (await _carRepository.GetCarsAsync(create.Plate) == null)
                {
                    City city = await _cityOperationsExtension.InsertCityIfDoesntExist(create.City);
                    Car car = BuildCar(create);
                    car.City = city;
                    await _baseRepository.AddAsync(car);
                }

                return Conflict();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        private static Car BuildCar(UserCarViewModel userViewModel)
        {
            CarBuilder carBuilder = new();
            carBuilder
                .WithPlate(userViewModel.Plate)
                .WithMaker(userViewModel.Maker)
                .WithModel(userViewModel.Model)
                .WithUserCpf(userViewModel.UserCpf)
                .WithPrice(userViewModel.Price)
                .WithMakeDate(userViewModel.MakeDate)
                .WithMakedDate(userViewModel.MakedDate)
                .WithKilometersTraveled(userViewModel.KilometersTraveled)
                .WithAcceptsChange(userViewModel.AcceptsChange)
                .WithIsArmored(userViewModel.IsArmored)
                .WithIsLicensed(userViewModel.IsLicensed)
                .WithIpvaIsPaid(userViewModel.IpvaIsPaid)
                .WithMessage(userViewModel.Message)
                .WithColor(userViewModel.Color)
                .WithTypeOfExchange(userViewModel.TypeOfExchange)
                .WithGasolineType(userViewModel.GasolineType);

            return carBuilder.GetResult();
        }
    }
}
