using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ICarRepository<T>
    {
        public Task<T> GetCarByPlateAsync(string plate);
        public Task<List<T>> GetAllCarsAsync();
        public Task<List<T>> GetByIdentificationAsync(string identification);
        public Task InsertCarAsync(T car);
        public Task UpdateCarAsync(T car);
        public Task IncreaseNumberOfViewsAsync(string carPlate);
        public Task DeleteCarAsync(string plate);
    }
}
