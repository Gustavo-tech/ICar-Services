﻿using ICar.API.Builders;
using ICar.API.Generators;
using ICar.API.OperationsExtension;
using ICar.API.ViewModels.Car;
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

        [HttpGet("get")]
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


        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCarAsync([FromBody] CarViewModel create)
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

        private static List<CarPicture> GenerateCarPictures(IEnumerable<string> pictures, Car car)
        {
            List<CarPicture> carPictures = new();

            foreach (string pic in pictures)
            {
                CarPicture carPicture = new()
                {
                    Car = car,
                    Picture = pic
                };
                carPictures.Add(carPicture);
            }

            return carPictures;
        }

        private static Car BuildCar(CarViewModel carVM, User owner)
        {
            CarBuilder carBuilder = new();
            carBuilder
                .WithPlate(carVM.Plate)
                .WithMaker(carVM.Maker)
                .WithModel(carVM.Model)
                .WithOwner(owner)
                .WithPrice(carVM.Price)
                .WithMakeDate(carVM.MakeDate)
                .WithMakedDate(carVM.MakedDate)
                .WithKilometersTraveled(carVM.KilometersTraveled)
                .WithAcceptsChange(carVM.AcceptsChange)
                .WithIsArmored(carVM.IsArmored)
                .WithIsLicensed(carVM.IsLicensed)
                .WithIpvaIsPaid(carVM.IpvaIsPaid)
                .WithMessage(carVM.Message)
                .WithColor(carVM.Color)
                .WithTypeOfExchange(carVM.TypeOfExchange)
                .WithGasolineType(carVM.GasolineType);

            Car car = carBuilder.GetResult();
            car.Pictures = GenerateCarPictures(carVM.CarImages, car);

            return car;
        }
    }
}
