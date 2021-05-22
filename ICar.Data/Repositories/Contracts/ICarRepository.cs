using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICarRepository
    {
        public Task<Car> GetCarByPlateAsync(string plate);
        public Task<List<Car>> GetAllCarsAsync();
        public Task<List<Car>> GetCarsByCpfAsync(string cpf);
        public Task<List<Car>> GetCarsByCnpjAsync(string cnpj);
        public Task InsertCarAsync(Car car);
        public Task UpdateCarAsync(Car car);
        public Task IncreaseNumberOfViewsAsync(string carPlate);
        public Task DeleteCarAsync(string plate);
    }
}
