using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.Cars;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface ICarQuery
    {
        public Car GetCar(string plate);
        public List<Car> GetAllCars();
        public List<Car> GetCarsWithCpf(string cpf);
        public List<Car> GetCarsWithCnpj(string cnpj);
        public void InsertCar(NewCar car);
        public void UpdateCar(Car car);
        public void IncreaseNumberOfViews(string carPlate);
        public void DeleteCar(int id);
    }
}
