using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ICarRepository<T>
    {
        public Task<T> GetCarByPlateAsync(string plate);
        public Task<List<T>> GetAllCarsAsync();
        public Task<List<T>> GetByIdentificationAsync(string identification);
        public Task IncreaseNumberOfViewsAsync(string carPlate);
    }
}
