using ICar.Data.Models.Entities;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ICityRepository
    {
        public Task<City> GetCityByIdAsync(int id);
    }
}
