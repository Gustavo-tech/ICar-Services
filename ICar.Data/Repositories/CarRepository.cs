using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext _dbContext;

        public CarRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByPlateAsync(string plate)
        {
            return await _dbContext.Cars.Where(x => x.Plate == plate).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetByIdentificationAsync(string identification)
        {
            return await _dbContext.Cars.Where(x => x.Discriminator == identification).ToListAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string carPlate)
        {
            Car uc = await _dbContext.Cars.Where(x => x.Plate == carPlate).FirstOrDefaultAsync();
            uc.NumberOfViews++;

            _dbContext.Update(uc);
            await _dbContext.SaveChangesAsync();
        }
    }
}
