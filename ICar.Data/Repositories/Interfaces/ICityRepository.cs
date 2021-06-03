using ICar.Infrastructure.Models;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByIdAsync(int id);
        Task<City> GetCityByNameAsync(string name);
    }
}
