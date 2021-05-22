using ICar.Data.Models.Entities.Cars;
using ICar.Data.Repositories.Contracts;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class UserCarRepository : ICarRepository<UserCar>, IUserCarRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserCarRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserCar>> GetAllCarsAsync()
        {
            return await _dbContext.UserCars.ToListAsync();
        }

        public async Task<UserCar> GetCarByPlateAsync(string plate)
        {
            return await _dbContext.UserCars.Where(x => x.Plate == plate).FirstOrDefaultAsync();
        }

        public async Task<UserCar> GetUserCarByCpfAsync(string cpf)
        {
            return await _dbContext.UserCars.Where(x => x.User.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task InsertCarAsync(UserCar car)
        {
            await _dbContext.UserCars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string carPlate)
        {
            UserCar uc = await _dbContext.UserCars.Where(x => x.Plate == carPlate).FirstOrDefaultAsync();
            uc.NumberOfViews++;

            _dbContext.Update(uc);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCarAsync(UserCar car)
        {
            _dbContext.UserCars.Update(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(string plate)
        {
            UserCar uc = await _dbContext.UserCars.Where(x => x.Plate == plate).FirstAsync();

            if (uc != null)
            {
                _dbContext.Remove(uc);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
