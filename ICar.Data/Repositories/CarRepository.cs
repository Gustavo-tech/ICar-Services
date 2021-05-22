using ICar.Data.Models.Entities;
using ICar.Data.Queries.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
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

        public async Task<List<Car>> GetCarsByCnpjAsync(string cnpj)
        {
            return await _dbContext.Cars.Where(x => x.CompanyCnpj == cnpj).ToListAsync();
        }
        public async Task<List<Car>> GetCarsByCpfAsync(string cpf)
        {
            return await _dbContext.Cars.Where(x => x.UserCpf == cpf).ToListAsync();
        }

        public async Task InsertCarAsync(Car car)
        {
            await _dbContext.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string carPlate)
        {
            Car car = await GetCarByPlateAsync(carPlate);
            car.NumberOfViews++;

            _dbContext.Update(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            _dbContext.Update(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(string plate)
        {
            Car car = await GetCarByPlateAsync(plate);

            if (car != null)
            {
                _dbContext.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
