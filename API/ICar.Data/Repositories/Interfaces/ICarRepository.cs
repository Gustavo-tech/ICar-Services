using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetCarsAsync();
        public Task<Car> GetCarByPlate(string plate);
        public Task<List<Car>> GetCarsByOwner(string email);
        public Task IncreaseNumberOfViewsAsync(string plate);
    }
}
