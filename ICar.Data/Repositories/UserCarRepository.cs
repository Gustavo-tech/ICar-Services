﻿using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class UserCarRepository : ICarRepository<UserCar>
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

        public async Task<List<UserCar>> GetByIdentificationAsync(string cpf)
        {
            return await _dbContext.UserCars.Where(x => x.User.Cpf == cpf).ToListAsync();
        }

        public async Task IncreaseNumberOfViewsAsync(string carPlate)
        {
            UserCar uc = await _dbContext.UserCars.Where(x => x.Plate == carPlate).FirstOrDefaultAsync();
            uc.NumberOfViews++;

            _dbContext.Update(uc);
            await _dbContext.SaveChangesAsync();
        }
    }
}
