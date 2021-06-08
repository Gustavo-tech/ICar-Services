using ICar.API.Builders;
using ICar.API.Generators;
using ICar.API.ViewModels.UserCar;
using ICar.Data.Converter;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IBaseRepository _baseRepository;

        public UserCarController(ICarRepository carRepository, IBaseRepository baseRepository)
        {
            _carRepository = carRepository;
            _baseRepository = baseRepository;
        }

        [HttpGet("get")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCarsAsync()
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

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCarAsync([FromBody] UserCarViewModel create)
        {
            try
            {
                if (await _carRepository.GetCarsAsync(create.Plate) == null)
                {
                    Car car = BuildCar(create);
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
