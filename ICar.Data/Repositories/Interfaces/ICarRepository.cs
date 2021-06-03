using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<Car> GetCarByPlateAsync(string plate);
        public Task<List<Car>> GetAllCarsAsync();
        public Task<List<Car>> GetByIdentificationAsync(string identification);
        public Task IncreaseNumberOfViewsAsync(string carPlate);
    }
}
