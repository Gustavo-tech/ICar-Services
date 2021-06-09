using ICar.Infrastructure.Models;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityAsync(int id);
        Task<City> GetCityAsync(string name);
    }
}
