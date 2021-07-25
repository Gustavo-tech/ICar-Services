using ICar.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<Car> GetCarAsync(string plate);
        public Task<List<Car>> GetCarsAsync();
        public Task<List<Car>> GetCarsAsync(string email);
        public Task IncreaseNumberOfViewsAsync(string plate);
    }
}
