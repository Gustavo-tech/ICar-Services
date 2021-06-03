using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class CompanyCityRepository : ICompanyCityRepository
    {
        private readonly DatabaseContext _dbContext;

        public CompanyCityRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompanyCity>> GetCompanyCitiesAsync()
        {
            return await _dbContext.CompanyCities.ToListAsync();
        }

        public async Task<List<CompanyCity>> GetCompanyCitiesAsync(string cnpj)
        {
            return await _dbContext.CompanyCities.Where(x => x.CompanyCnpj == cnpj).ToListAsync();
        }

        public async Task<List<CompanyCity>> GetCompanyCitiesAsync(int cityId)
        {
            return await _dbContext.CompanyCities.Where(x => x.CityId == cityId).ToListAsync();
        }

        public async Task<CompanyCity> GetCompanyCityAsync(string cnpj, int cityId)
        {
            return await _dbContext.CompanyCities.Where(x => x.CompanyCnpj == cnpj && x.CityId == cityId)
                .FirstOrDefaultAsync();
        }
    }
}
