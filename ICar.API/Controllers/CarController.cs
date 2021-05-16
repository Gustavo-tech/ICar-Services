using ICar.API.Validations;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarQuery _carQuery;

        public CarController(ICarQuery carQuery)
        {
            _carQuery = carQuery;
        }

        [HttpGet("all")]
        public IActionResult GetCars()
        {
            try
            {
                List<Car> carsInDatabase = _carQuery.GetAllCars();

                List<dynamic> carsOutput = new List<dynamic>();

                foreach (Car car in carsInDatabase)
                {
                    carsOutput.Add(new
                    {
                        Plate = car.Plate,
                        Maker = car.Maker,
                        Model = car.Model,
                        MakeDate = car.MakeDate,
                        MakedDate = car.MakedDate,
                        KilometersTraveled = car.KilometersTraveled,
                        Price = car.Price,
                        AcceptsChange = car.AcceptsChange,
                        IpvaIsPaid = car.IpvaIsPaid,
                        IsLicensed = car.IsLicensed,
                        IsArmored = car.IsArmored,
                        Message = car.Message,
                        Color = CarPropertyConverter.ConvertColorToString(car.Color),
                        GasolineType = CompleteGasolineType(CarPropertyConverter.ConvertGasolineTypeToString(car.GasolineType)),
                        City = car.City
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
        public IActionResult GetCar([FromRoute] string plate)
        {
            plate = plate.ToUpper();
            if (CarValidator.ValidatePlate(plate))
            {
                try
                {
                    return Ok(_carQuery.GetCar(plate));
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

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetUserCars([FromRoute] string cpf)
        {
            if (UserValidator.ValidateCpf(cpf))
            {
                try
                {
                    return Ok(_carQuery.GetCarsWithCpf(cpf));
                }
                catch (Exception exception)
                {
                    return Problem(title: "Some error happened while getting cars of this user",
                        detail: exception.Message);
                }
            }

            return BadRequest(new
            {
                Message = "This is not a valid CPF"
            });
        }

        [HttpGet("cnpj/{cnpj}")]
        public IActionResult GetCompanyCars([FromRoute] string cnpj)
        {
            if (CompanyValidator.ValidateCnpj(cnpj))
            {
                try
                {
                    return Ok(_carQuery.GetCarsWithCnpj(cnpj));
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

        [HttpPost("insert")]
        public async Task<IActionResult> InsertCar()
        {
            NewCar newCar = GetNewCarFromRequest();
            List<string> carPictures = await GetImagesStreams();

            List<InvalidReason> invalidReasons = CarValidator.ValidateNewCar(newCar);
            if (invalidReasons == null)
            {
                try
                {
                    _carQuery.InsertCar(newCar);
                    await _carQuery.InsertCarPictures(carPictures, newCar.Plate);
                    return Ok();
                }
                catch (Exception e)
                {
                    return Problem(title: "Some error occurred while inserting this car",
                        detail: e.Message);
                }
            }

            else
            {
                return BadRequest(new
                {
                    Message = "This car is invalid",
                    Reasons = invalidReasons
                });
            }
        }

        [HttpPost("increase/views")]
        public IActionResult IncreaseNumberOfViews([FromBody] CarPlate carPlate)
        {
            if (CarValidator.ValidatePlate(carPlate.Plate))
            {
                try
                {
                    _carQuery.IncreaseNumberOfViews(carPlate.Plate);
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

        [HttpDelete("delete/{plate}")]
        public async Task<IActionResult> DeleteCar([FromRoute] string plate)
        {
            plate = plate.ToUpper();
            try
            {
                await _carQuery.DeleteCarPictures(plate);
                await _carQuery.DeleteCar(plate);
                return Ok();
            }
            catch(Exception e)
            {
                return Problem(title: "Some error occurred", detail: e.Message);
            }
        }

        private string CompleteGasolineType(string gasolineType)
        {
            gasolineType = gasolineType.ToLower();

            switch (gasolineType)
            {
                case "die":
                    return "Diesel";
                case "ele":
                    return "Eletric";
                case "gad":
                    return "Gasoline and Diesel";
                default:
                    return "Gasoline";
            }
        }

        private NewCar GetNewCarFromRequest()
        {
            Dictionary<string, string> answersDictionary = new Dictionary<string, string>
            {
                { "plate", "" },
                { "maker", "" },
                { "model", "" },
                { "makeDate", "" },
                { "makedDate", "" },
                { "kilometersTraveled", "" },
                { "typeOfExchange", "" },
                { "price", "" },
                { "color", "" },
                { "acceptsChange", "" },
                { "ipvaIsPaid", "" },
                { "city", "" },
                { "isLicensed", "" },
                { "gasolineType", "" },
                { "isArmored", "" },
                { "message", "" },
                { "userCpf", "" },
                { "companyCnpj", "" },
            };

            foreach (KeyValuePair<string, string> kvp in answersDictionary)
            {
                HttpContext.Request.Form.TryGetValue(kvp.Key, out StringValues answer);
                answersDictionary[kvp.Key] = answer.ToString();
            }

            return new NewCar(answersDictionary["plate"], answersDictionary["maker"], answersDictionary["model"],
                int.Parse(answersDictionary["makedDate"]), int.Parse(answersDictionary["makedDate"]), double.Parse(answersDictionary["kilometersTraveled"]),
                answersDictionary["typeOfExchange"], double.Parse(answersDictionary["price"]), answersDictionary["color"],
                ConvertStringToBool(answersDictionary["acceptsChange"]), ConvertStringToBool(answersDictionary["ipvaIsPaid"]), ConvertStringToBool(answersDictionary["isLicensed"]),
                answersDictionary["gasolineType"], ConvertStringToBool(answersDictionary["isArmored"]), answersDictionary["message"],
                answersDictionary["city"], answersDictionary["userCpf"], answersDictionary["companyCnpj"]);
        }

        private async Task<List<string>> GetImagesStreams()
        {
            List<string> streams = new();
            bool stillHasImages = true;
            int indexToAccess = 1;

            while (stillHasImages)
            {
                IFormFile file = HttpContext.Request.Form.Files.GetFile($"picture{indexToAccess}");

                if (file != null)
                {
                    StreamReader sr = new StreamReader(file.OpenReadStream());
                    string content = await sr.ReadToEndAsync();
                    streams.Add(content);
                    indexToAccess++;
                }
                else
                {
                    stillHasImages = false;
                }
            }

            return streams;
        }

        private bool ConvertStringToBool(string value)
        {
            return value == "true";
        }
    }
}
