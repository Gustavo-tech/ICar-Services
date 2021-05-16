using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICarQuery
    {
        public Car GetCar(string plate);
        public List<Car> GetAllCars();
        public List<Car> GetCarsWithCpf(string cpf);
        public List<Car> GetCarsWithCnpj(string cnpj);
        public Task InsertCar(NewCar car);
        public Task InsertCarPictures(List<string> pictures, string carPlate);
        public Task UpdateCar(Car car);
        public Task IncreaseNumberOfViews(string carPlate);
        public Task DeleteCarPictures(string plate);
        public Task DeleteCar(string plate);
    }
}
