using ICar.Infrastructure.Models;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityAsync(int id);
        Task<City> GetCityAsync(string name);
        Task<City> InsertAsync(string cityName);
    }
}
