using ICar.Data.Models.Entities.Cars;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Cars
{
    public class CompanyCarRepository : ICarRepository<CompanyCar>
    {
        private readonly DatabaseContext _dbContext;

        public CompanyCarRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompanyCar>> GetAllCarsAsync()
        {
            return await _dbContext.CompanyCars.ToListAsync();
        }

        public async Task<CompanyCar> GetCarByPlateAsync(string plate)
        {
            return await _dbContext.CompanyCars.Where(x => x.Plate == plate).FirstOrDefaultAsync();
        }

        public async Task<List<CompanyCar>> GetByIdentificationAsync(string cnpj)
        {
            return await _dbContext.CompanyCars.Where(x => x.Company.Cnpj == cnpj).ToListAsync();
        }

        public async Task InsertCarAsync(CompanyCar car)
        {
            await _dbContext.CompanyCars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string carPlate)
        {
            CompanyCar uc = await _dbContext.CompanyCars.Where(x => x.Plate == carPlate).FirstOrDefaultAsync();
            uc.NumberOfViews++;

            _dbContext.Update(uc);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(CompanyCar car)
        {
            _dbContext.CompanyCars.Update(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(string plate)
        {
            CompanyCar uc = await _dbContext.CompanyCars.Where(x => x.Plate == plate).FirstAsync();

            if (uc != null)
            {
                _dbContext.Remove(uc);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
