using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class CompanyLoginRepository : ILoginRepository<CompanyLogin>
    {
        private readonly DatabaseContext _dbContext;

        public CompanyLoginRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompanyLogin>> GetAllLogins()
        {
            return await _dbContext.CompanyLogins.ToListAsync();
        }
    }
}
