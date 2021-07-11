﻿using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ICarContext _dbContext;

        public LoginRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Login>> GetAllLogins()
        {
            return await _dbContext.Logins.ToListAsync();
        }
    }
}