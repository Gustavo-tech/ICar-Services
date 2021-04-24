using ICar.API.ViewModels;
using ICar.Data.Queries.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase {
        private readonly ICarQuery _carQuery;

        public CarController(ICarQuery carQuery) {
            _carQuery = carQuery;
        }

        public IActionResult GetCars() {
            try {
                return Ok(_carQuery.GetAllCars());
            }
            catch (Exception exception) {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        public IActionResult GetCar([FromBody] CarPlate carPlate) {
            try {
                return Ok(_carQuery.GetCar(carPlate.Plate));
            }
            catch (Exception exception) {
                return Problem(title: "Some error happened while getting the cars",
                    detail: exception.Message);
            }
        }

        public IActionResult GetUserCars([FromBody] UserCpf userCpf) {
            try {
                return Ok(_carQuery.GetCarsWithCpf(userCpf.Cpf));
            }
            catch (Exception exception) {
                return Problem(title: "Some error happened while getting cars of this user",
                    detail: exception.Message);
            }
        }

        public IActionResult GetCompanyCars([FromBody] CompanyCnpj companyCnpj) {
            try {
                return Ok(_carQuery.GetCarsWithCnpj(companyCnpj.Cnpj));
            }
            catch (Exception exception) {
                return Problem(title: "Some error happened while getting cars of this user",
                    detail: exception.Message);
            }
        }

        public IActionResult IncreaseNumberOfViews([FromBody] CarPlate carPlate) {
            try {
                _carQuery.IncreaseNumberOfViews(carPlate.Plate);
                return Ok("Number of views updated successfully");
            }
            catch (Exception exception) {
                return Problem(title: "Some error happened while updating the number of views",
                    detail: exception.Message);
            }
        }
    }
}
