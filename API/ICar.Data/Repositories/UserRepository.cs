﻿using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ICarContext _dbContext;

        public UserRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByCpfAsync(string cpf)
        {
            return await _dbContext.Users
                .Where(x => x.Cpf == cpf)
                .Include(x => x.News)
                .Include(x => x.Logins)
                .Include(x => x.Cars)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.Users
                .Include(x => x.News)
                .Include(x => x.Cars)
                .Include(x => x.Logins)
                .ToListAsync();
        }

        public async Task<List<Login>> GetUserLoginsAsync(string cpf)
        {
            return await _dbContext.Logins.Where(x => x.UserCpf == cpf).ToListAsync();
        }
    }
}