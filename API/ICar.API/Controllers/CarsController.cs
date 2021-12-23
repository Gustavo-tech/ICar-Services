using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using ICar.Infrastructure.Storage;
using ICar.Infrastructure.ViewModels.Input.Car;
using ICar.Infrastructure.ViewModels.Output.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IStorageService _storageService;

        public CarsController(ICarRepository carRepository, IBaseRepository baseRepository,
            IStorageService storageService)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _storageService = storageService;
        }

        [HttpGet("mycars")]
        public async Task<IActionResult> GetMyCarsAsync()
        {
            try
            {
                string ownerId = HttpContext.GetUserObjectId();
                List<Car> userCars = await _carRepository.GetUserCarsAsync(ownerId);
                CarOverviewViewModel[] output = userCars.Select(x => x.GenerateOverviewViewModel()).ToArray();
                return Ok(output);
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: ex.Message);
            }
        }

        [HttpGet("selling")]
        public async Task<IActionResult> GetCarsAsync([FromQuery] CarSearchModel search)
        {
            try
            {
                List<Car> cars = await _carRepository.GetCarsAsync(search);
                CarOverviewViewModel[] output = cars.Select(x => x.GenerateOverviewViewModel()).ToArray();
                return Ok(output);
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened while getting the cars",
                    detail: ex.Message);
            }
        }

        [HttpGet("selling/{id}")]
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

        [HttpPost("create")]
        public async Task<IActionResult> InsertCarAsync([FromBody] InsertCarViewModel create)
        {
            try
            {
                Car cInDatabase = await _carRepository.GetCarByPlateAsync(create.Plate);
                if (cInDatabase is null)
                {
                    try
                    {
                        string ownerId = HttpContext.GetUserObjectId();
                        Car car = await Car.GenerateWithInsertCarViewModel(create, ownerId);
                        await _storageService.UploadCarPicturesAsync(car, create.Pictures);
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

        [HttpPut("views/{id}")]
        public async Task<IActionResult> IncrementNumberOfViewsAsync([FromRoute] string id)
        {
            try
            {
                Car car = await _carRepository.GetCarByIdAsync(id);

                if (car != null)
                {
                    car.IncreaseNumberOfViews();
                    await _baseRepository.UpdateAsync(car);
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

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCarAsync([FromBody] UpdateCarViewModel vm)
        {
            try
            {
                Car car = await _carRepository.GetCarByIdAsync(vm.Id);

                if (car != null)
                {
                    bool removedPictures = false;
                    int picIndex = 0;
                    while (!removedPictures)
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
                    await _storageService.UploadCarPicturesAsync(car, vm.Pictures);
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
        public async Task<IActionResult> DeleteCarAsync([FromBody] DeleteCarViewModel vm)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Car car = await _carRepository.GetCarByIdAsync(vm.CarId);                

                if (car != null && car.OwnerId == userId)
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
    }
}
