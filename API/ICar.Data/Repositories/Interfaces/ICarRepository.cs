using ICar.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public Task<Car> GetCarsAsync(string plate);
        public Task<List<Car>> GetUserCarsAsync();
        public Task<List<Car>> GetUserCarsAsync(string userCpf);
        public Task<List<Car>> GetCompanyCarsAsync();
        public Task<List<Car>> GetCompanyCarsAsync(string companyCnpj);
        public Task IncreaseNumberOfViewsAsync(string carPlate);
    }
}
