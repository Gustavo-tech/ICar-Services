using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<Car> GetCarByPlateAsync(string plate);
        public Task<Car> GetCarByIdAsync(string id);
        public Task<List<Car>> GetCarsAsync(CarSearchModel search);
        public Task<List<Car>> GetUserCarsAsync(string ownerId, CarSearchModel search);
        public Task<List<Car>> GetMostSeenCarsAsync(int quantity);
        public Task<string[]> GetMostSeenMakers(int quantity);
    }
}
