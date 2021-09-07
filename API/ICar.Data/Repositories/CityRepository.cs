using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<City> InsertAsync(string cityName)
        {
            City cityInDatabase = await _dbContext.Cities.Where(x => x.Name == cityName).FirstOrDefaultAsync();

            if (cityInDatabase == null)
            {
                City newCity = new(cityName);
                await _dbContext.Cities.AddAsync(newCity);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.Cities.Where(x => x.Name == cityName).FirstOrDefaultAsync();
            }

            return cityInDatabase;
        }
    }
}
