using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Accounts
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
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByCnpjAsync(string cnpj)
        {
            return await _dbContext.Companies.Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync();
        }

        public async Task<Company> GetCompanyByEmailAsync(string email)
        {
            return await _dbContext.Companies.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task InsertCompany(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}
