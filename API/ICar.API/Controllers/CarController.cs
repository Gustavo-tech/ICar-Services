﻿using ICar.API.Builders;
using ICar.API.Generators;
using ICar.API.OperationsExtension;
using ICar.API.ViewModels.UserCar;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IBaseRepository _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly CityOperationsExtension _cityOperationsExtension;

        public CarController(ICityRepository cityRepository, ICarRepository carRepository, IBaseRepository baseRepository, 
            IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _userRepository = userRepository;
            _cityOperationsExtension = new(cityRepository, baseRepository);
        }

        [HttpGet("user/get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllCarsAsync()
        {
            try
            {
                List<Car> carsInDatabase = await _carRepository.GetCarsAsync();
                dynamic[] output = CarOutputFactory.GenerateUserCarOutput(carsInDatabase);
                return Ok(output);
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
                    User owner = await _userRepository.GetUserByEmailAsync(create.UserEmail);
                    Car car = BuildCar(create, owner);
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

        private static Car BuildCar(UserCarViewModel userViewModel, User owner)
        {
            CarBuilder carBuilder = new();
            carBuilder
                .WithPlate(userViewModel.Plate)
                .WithMaker(userViewModel.Maker)
                .WithModel(userViewModel.Model)
                .WithOwner(owner)
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
