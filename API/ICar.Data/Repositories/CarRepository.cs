using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICar.Infrastructure.Repositories.Search;

namespace ICar.Infrastructure.Database.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarContext _dbContext;

        public CarRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetCarByIdAsync(string id)
        {
            return await _dbContext.Cars
                .Where(x => x.Id == id)
                .Include(x => x.Address)
                .Include(x => x.Pictures)
                .FirstOrDefaultAsync();
        }

        public async Task<Car> GetCarByPlateAsync(string plate)
        {
            return await _dbContext.Cars
                .Where(x => x.Plate == plate)
                .Include(x => x.Address)
                .Include(x => x.Pictures)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarsAsync(CarSearchModel search)
        {
            List<Car> cars = await _dbContext.Cars
                .Include(x => x.Pictures)
                .Include(x => x.Address)
                .ToListAsync();

            if (search.Maker is not null)
                cars = cars.Where(x => x.Maker == search.Maker).ToList();

            if (search.Model is not null)
                cars = cars.Where(x => x.Model == search.Model).ToList();

            if (search.MinPrice is not null)
                cars = cars.Where(x => x.Price >= search.MinPrice.Value).ToList();

            if (search.MaxPrice is not null)
                cars = cars.Where(x => x.Price <= search.MaxPrice.Value).ToList();

            if (search.MaxKilometers is not null)
                cars = cars.Where(x => x.KilometersTraveled <= search.MaxKilometers.Value).ToList();

            return cars;
        }

        public async Task<List<Car>> GetCarsAsync(string email)
        {
            return await _dbContext.Cars
                .Where(x => x.Owner.Email == email)
                .Include(x => x.Pictures)
                .Include(x => x.Address)
                .ToListAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _dbContext.Cars.Update(car);
            await _dbContext.SaveChangesAsync();
        }
    }
}
