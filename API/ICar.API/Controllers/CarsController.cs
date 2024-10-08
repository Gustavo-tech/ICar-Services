﻿using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.Repositories.Search;
using ICar.Infrastructure.Storage;
using ICar.Infrastructure.ViewModels.Input;
using ICar.Infrastructure.ViewModels.Output;
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
        private readonly IContactRepository _contactRepository;

        public CarsController(ICarRepository carRepository, IBaseRepository baseRepository,
            IStorageService storageService, IContactRepository contactRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
            _storageService = storageService;
            _contactRepository = contactRepository;
        }

        [HttpGet("mycars")]
        public async Task<IActionResult> GetMyCarsAsync([FromQuery] string maker, [FromQuery] string model, [FromQuery] int? maxPrice,
            [FromQuery] int? maxKilometers, [FromQuery] int minPrice = 0)
        {
            try
            {
                CarSearchModel search = new(maker, model, minPrice, maxPrice, maxKilometers);
                string ownerId = HttpContext.GetUserObjectId();
                List<Car> userCars = await _carRepository.GetUserCarsAsync(ownerId, search);
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
        public async Task<IActionResult> GetCarsAsync([FromQuery] string maker, [FromQuery] string model, [FromQuery] int? maxPrice,
            [FromQuery] int? maxKilometers, [FromQuery] int minPrice = 0)
        {
            try
            {
                CarSearchModel search = new(maker, model, minPrice, maxPrice, maxKilometers);
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
                Contact contact = await _contactRepository.GetContactAsync(car.OwnerId);

                if (car != null)
                {
                    CarOutputViewModel output = CarOutputViewModel.GenerateCarOutputViewModelWithCar(car, contact);
                    return Ok(output);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(title: "Some error happened", detail: ex.Message);
            }
        }

        [HttpGet("mostseen/cars")]
        public async Task<IActionResult> GetMostSeenCarsAsync([FromQuery] int quantity)
        {
            try
            {
                List<Car> mostSeenCars = await _carRepository.GetMostSeenCarsAsync(quantity);
                List<CarOverviewViewModel> viewModels = mostSeenCars.Select(x => x.GenerateOverviewViewModel()).ToList();

                return Ok(viewModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpGet("mostseen/makers")]
        public async Task<IActionResult> GetMostSeenMakersAsync([FromQuery] int quantity)
        {
            try
            {
                string[] mostSeenMakers = await _carRepository.GetMostSeenMakers(quantity);
                return Ok(mostSeenMakers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> InsertCarAsync([FromBody] InsertCarViewModel create)
        {
            try
            {
                string ownerId = HttpContext.GetUserObjectId();
                Contact contact = await _contactRepository.GetContactAsync(ownerId);

                if (contact is null)
                    return BadRequest();

                Car cInDatabase = await _carRepository.GetCarByPlateAsync(create.Plate);
                if (cInDatabase is null)
                {
                    try
                    {
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
                string userId = HttpContext.GetUserObjectId();
                Car car = await _carRepository.GetCarByIdAsync(id);

                if (userId == car.OwnerId)
                    return BadRequest();

                if (car != null)
                {
                    car.IncreaseNumberOfViews();
                    await _baseRepository.UpdateAsync(car);
                    return Ok();
                }

                return NotFound("We could not find a car with this id");
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
                string userId = HttpContext.GetUserObjectId();
                Car car = await _carRepository.GetCarByIdAsync(vm.Id);

                if (car != null && car.OwnerId == userId)
                {
                    if (vm.Pictures.Any(x => x.Contains("base64")))
                    {
                        int picIndex = 0;
                        while (car.Pictures.Any())
                        {
                            CarPicture picture = car.Pictures[picIndex];
                            await _baseRepository.DeleteAsync(picture);
                            await _storageService.DeleteBlobAsync(picture.GenerateStoragePath());
                            picIndex++;
                        }

                        car.UpdatePictures(vm.Pictures);
                        await _storageService.UploadCarPicturesAsync(car, vm.Pictures);
                    }

                    await car.UpdateAddress(vm.ZipCode, vm.Location, vm.District, vm.Street);
                    car.UpdateBooleanProperties(vm.AcceptsChange, vm.IpvaIsPaid, vm.IsLicensed, vm.IsArmored);
                    car.UpdateMessage(vm.Message)
                       .UpdatePrice(vm.Price)
                       .UpdateKilometersTraveled(vm.KilometersTraveled);

                    await _baseRepository.UpdateAsync(car);
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] string id)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Car car = await _carRepository.GetCarByIdAsync(id);                

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
