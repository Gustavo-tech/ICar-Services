using ICar.API.Builders;
using ICar.API.ViewModels.Car;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICar.Infrastructure.Repositories.Search;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;

        public CarsController(ICityRepository cityRepository, ICarRepository carRepository, IBaseRepository baseRepository, 
            IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _userRepository = userRepository;
            _cityRepository = cityRepository;
        }

        [HttpGet("{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMyCars([FromRoute] string email)
        {
            try
            {
                List<Car> userCars = await _carRepository.GetCarsAsync(email);
                dynamic[] output = userCars.Select(x => x.GenerateApiOutput()).ToArray();
                return Ok(output);
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: ex.Message);
            }
        }

        [HttpGet("selling")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCars([FromQuery] CarSearchModel search)
        {
            try
            {
                List<Car> cars = await _carRepository.GetCarsAsync(search);
                dynamic[] output = cars.Select(x => x.GenerateOverview()).ToArray();
                return Ok(output);
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: ex.Message);
            }
        }

        [HttpGet("selling/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            try
            {
                Car car = await _carRepository.GetCarAsync(id);

                if (car != null)
                {
                    dynamic output = car.GenerateApiOutput();
                    return Ok(output);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened", detail: ex.Message);
            }
        }

        [HttpPost("views/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> IncrementNumberOfViews([FromRoute] int id)
        {
            try
            {
                Car car = await _carRepository.GetCarAsync(id);

                if (car != null)
                {
                    car.IncreaseNumberOfViews();
                    await _carRepository.UpdateAsync(car);
                    return Ok();
                }

                return NotFound(new
                {
                    Message = "We could not find a car with this id"
                });
            }
            catch(Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCarAsync([FromBody] CarViewModel create)
        {
            try
            {
                if (await _carRepository.GetCarAsync(create.Plate) == null)
                {
                    City city = await _cityRepository.InsertAsync(create.City);
                    User owner = await _userRepository.GetUserByEmailAsync(create.UserEmail);
                    Car car = BuildCar(create, owner);
                    car.City = city;
                    await _baseRepository.AddAsync(car);
                    return Ok();
                }

                return Problem();
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
                carPictures.Add(new CarPicture(pic, car));
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
                .WithExchangeType(carVM.ExchangeType)
                .WithGasolineType(carVM.GasolineType);

            Car car = carBuilder.GetResult();
            car.Pictures = GenerateCarPictures(carVM.Pictures, car);

            return car;
        }
    }
}
