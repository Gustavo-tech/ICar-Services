using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetCarsAsync(CarSearchModel carSearchModel);
        public Task<List<Car>> GetCarsAsync(string email);
        public Task<Car> GetCarByPlateAsync(string plate);
        public Task<Car> GetCarByIdAsync(string id);
        public Task UpdateAsync(Car car);
    }
}
