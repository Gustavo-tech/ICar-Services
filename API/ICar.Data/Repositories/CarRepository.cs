using ICar.Infrastructure.Database.Models;
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

        public async Task<Car> GetCarsAsync(string plate)
        {
            return await _dbContext.Cars.Where(x => x.Plate == plate).FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetUserCarsAsync()
        {
            return await _dbContext.Cars
                .Where(x => x.UserCpf != null)
                .ToListAsync();
        }

        public async Task<List<Car>> GetUserCarsAsync(string userCpf)
        {
            return await _dbContext.Cars.Where(x => x.UserCpf == userCpf).ToListAsync();
        }

        public async Task<List<Car>> GetCompanyCarsAsync()
        {
            return await _dbContext.Cars
                .Where(x => x.CompanyCnpj != null)
                .ToListAsync();
        }

        public async Task<List<Car>> GetCompanyCarsAsync(string companyCnpj)
        {
            return await _dbContext.Cars.Where(x => x.CompanyCnpj == companyCnpj).ToListAsync();
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
