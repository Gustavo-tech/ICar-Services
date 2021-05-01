using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface ICarQuery
    {
        public CarInSystem GetCar(string plate);
        public List<CarInSystem> GetAllCars();
        public List<CarInSystem> GetCarsWithCpf(string cpf);
        public List<CarInSystem> GetCarsWithCnpj(string cnpj);
        public void InsertCar(Car car);
        public void UpdateCar(CarInSystem car);
        public void IncreaseNumberOfViews(string carPlate);
        public void DeleteCar(int id);
    }
}
