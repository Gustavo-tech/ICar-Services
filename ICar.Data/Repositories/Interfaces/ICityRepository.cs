using ICar.Data.Models.Entities;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByIdAsync(int id);
        Task<City> GetCityByNameAsync(string name);
        Task InsertCityAsync(City city);
    }
}
