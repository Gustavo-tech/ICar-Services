using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DatabaseContext _dbContext;

        public CityRepository(DatabaseContext dbContext)
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
