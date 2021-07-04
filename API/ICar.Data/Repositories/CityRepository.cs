using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ICarContext _dbContext;

        public CityRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> GetCityAsync(int id)
        {
            return await _dbContext.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<City> GetCityAsync(string name)
        {
            return await _dbContext.Cities.Where(x => x.Name == name).FirstOrDefaultAsync();
        }
    }
}
