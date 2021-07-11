﻿using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ICarContext _dbContext;

        public CompanyRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _dbContext.Companies
                .Include(x => x.Cars)
                .Include(x => x.Logins)
                .Include(x => x.News)
                .ToListAsync();
        }

        public async Task<Company> GetCompanyByCnpjAsync(string cnpj)
        {
            return await _dbContext.Companies
                .Where(x => x.Cnpj == cnpj)
                .Include(x => x.Cars)
                .Include(x => x.Logins)
                .Include(x => x.News)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetCompanyByEmailAsync(string email)
        {
            return await _dbContext.Companies
                .Where(x => x.Email == email)
                .Include(x => x.Cars)
                .Include(x => x.Logins)
                .Include(x => x.News)
                .FirstOrDefaultAsync();
        }
    }
}