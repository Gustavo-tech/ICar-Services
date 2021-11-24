using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using ICar.Infrastructure.ViewModels.Input.Car;
using ICar.Infrastructure.ViewModels.Output.Car;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IUserRepository _userRepository;

        public CarsController(ICarRepository carRepository, IBaseRepository baseRepository,
            IUserRepository userRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMyCars([FromRoute] string email)
        {
            try
            {
                List<Car> userCars = await _carRepository.GetCarsAsync(email);
                CarOutputViewModel[] output = userCars.Select(x => x.GenerateCarOutputViewModel()).ToArray();
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
                dynamic[] output = cars.Select(x => x.GenerateOverviewViewModel()).ToArray();
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
        public async Task<IActionResult> GetCar([FromRoute] string id)
        {
            try
            {
                Car car = await _carRepository.GetCarByIdAsync(id);

                if (car != null)
                {
                    CarOutputViewModel output = car.GenerateCarOutputViewModel();
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
        public async Task<IActionResult> IncrementNumberOfViews([FromRoute] string id)
        {
            try
            {
                Car car = await _carRepository.GetCarByIdAsync(id);

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
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCarAsync([FromBody] InsertCarViewModel create)
        {
            try
            {
                Car cInDatabase = await _carRepository.GetCarByPlateAsync(create.Plate);
                if (cInDatabase is null)
                {
                    try
                    {
                        User owner = await _userRepository.GetUserByEmailAsync(create.UserEmail);
                        Car car = await Car.GenerateWithInsertCarViewModel(create, owner);
                        await _baseRepository.AddAsync(car);
                        return Ok();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return BadRequest(new { e.Message });
                    }
                }

                return BadRequest(new { Message = "This car is already registered" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
    }
}
