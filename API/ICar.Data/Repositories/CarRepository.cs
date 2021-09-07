using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ICarContext _dbContext;

        public CarRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetCarByPlate(string plate)
        {
            return await _dbContext.Cars
                .Where(x => x.Plate == plate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<List<Car>> GetCarsByOwner(string email)
        {
            return await _dbContext.Cars
                .Where(x => x.Owner.Email == email)
                .Include(x => x.Pictures)
                .Include(x => x.City)
                .ToListAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string plate)
        {
            Car car = await _dbContext.Cars
                .Where(x => x.Plate == plate)
                .FirstOrDefaultAsync();

            car.NumberOfViews++;

            _dbContext.Update(car);
            await _dbContext.SaveChangesAsync();
        }
    }
}
