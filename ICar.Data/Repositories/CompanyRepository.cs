﻿using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _dbContext;

        public CompanyRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _dbContext.Companies
                .Include(x => x.CompanyCars)
                .Include(x => x.CompanyLogins)
                .Include(x => x.CompanyNews)
                .Include(x => x.Cities)
                .ToListAsync();
        }

        public async Task<Company> GetCompanyByCnpjAsync(string cnpj)
        {
            return await _dbContext.Companies
                .Where(x => x.Cnpj == cnpj)
                .Include(x => x.CompanyCars)
                .Include(x => x.CompanyLogins)
                .Include(x => x.CompanyNews)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetCompanyByEmailAsync(string email)
        {
            return await _dbContext.Companies
                .Where(x => x.Email == email)
                .Include(x => x.CompanyCars)
                .Include(x => x.CompanyLogins)
                .Include(x => x.CompanyNews)
                .FirstOrDefaultAsync();
        }
    }
}
