using ICar.Data.Models.Entities;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DatabaseContext _dbContext;

        public CityRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _dbContext.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            return await _dbContext.Cities.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task InsertCityAsync(City city)
        {
            _dbContext.Cities.Add(city);
            await _dbContext.SaveChangesAsync();
        }
    }
}
