using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class CompanyNewsRepository : INewsRepository<CompanyNews>
    {
        private readonly DatabaseContext _dbContext;

        public CompanyNewsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CompanyNews>> GetNewsAsync()
        {
            return await _dbContext.CompanyNews.ToListAsync();
        }
    }
}
