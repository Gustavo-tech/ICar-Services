using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using ICar.Infrastructure.Storage;
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
        private readonly IStorageService _storageService;

        public CarsController(ICarRepository carRepository, IBaseRepository baseRepository,
            IUserRepository userRepository, IStorageService storageService)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _userRepository = userRepository;
            _storageService = storageService;
        }

        [HttpGet("{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMyCarsAsync([FromRoute] string email)
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
        public async Task<IActionResult> GetCarsAsync([FromQuery] CarSearchModel search)
        {
            try
            {
                List<Car> cars = await _carRepository.GetCarsAsync(search);
                CarOutputViewModel[] output = cars.Select(x => x.GenerateCarOutputViewModel()).ToArray();
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
        public async Task<IActionResult> GetCarAsync([FromRoute] string id)
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
        public async Task<IActionResult> IncrementNumberOfViewsAsync([FromRoute] string id)
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
                        await UploadCarPictures(car, create.Pictures);
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

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateCarAsync([FromBody] UpdateCarViewModel vm)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(vm.OwnerEmail);
                Car car = await _carRepository.GetCarByIdAsync(vm.Id);

                if (user != null && car != null && car.Owner.Id == user.Id)
                {
                    bool removedPictures = false;
                    int picIndex = 0;
                    while(!removedPictures)
                    {
                        CarPicture picture = car.Pictures[picIndex];
                        await _baseRepository.DeleteAsync(picture);
                        await _storageService.DeleteBlobAsync(picture.GenerateStoragePath());
                        removedPictures = car.Pictures.Count == 0;
                        picIndex++;
                    }
                    await car.UpdateAddress(vm.ZipCode, vm.Location, vm.District, vm.Street);
                    car.UpdateBooleanProperties(vm.AcceptsChange, vm.IpvaIsPaid, vm.IsLicensed, vm.IsArmored);
                    car.UpdateMessage(vm.Message)
                       .UpdatePrice(vm.Price)
                       .UpdateKilometersTraveled(vm.KilometersTraveled)
                       .UpdatePictures(vm.Pictures);

                    await _baseRepository.UpdateAsync(car);
                    await UploadCarPictures(car, vm.Pictures);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCarAsync([FromBody] DeleteCarViewModel vm)
        {
            try
            {
                User owner = await _userRepository.GetUserByEmailAsync(vm.OwnerEmail);
                Car car = await _carRepository.GetCarByIdAsync(vm.CarId);

                if (car != null && owner != null && car.Owner.Id == owner.Id)
                {
                    await _baseRepository.DeleteAsync(car);
                    foreach (CarPicture picture in car.Pictures)
                    {
                        await _storageService.DeleteBlobAsync(picture.GenerateStoragePath());
                    }
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        private async Task UploadCarPictures(Car car, string[] pictures)
        {
            if (car is null || pictures is null)
                return;

            for (int i = 0; i < pictures.Length; i++)
            {
                string url = car.Pictures[i].GenerateStoragePath();
                string base64 = pictures[i];
                await _storageService.UploadPictureAsync(url, base64);
            }
        }
    }
}
