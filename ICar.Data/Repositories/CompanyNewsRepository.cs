using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
{
    public class CompanyNewsRepository : ICompanyNewsRepository
    {
        private readonly DatabaseContext _dbContext;

        public CompanyNewsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteCompanyNewsAsync(int id)
        {
            CompanyNews cn = await _dbContext.CompanyNews.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (cn != null)
            {
                _dbContext.CompanyNews.Remove(cn);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyNews>> GetCompanyNewsAsync()
        {
            return await _dbContext.CompanyNews.ToListAsync();
        }

        public async Task InsertCompanyNewsAsync(CompanyNews news)
        {
            await _dbContext.CompanyNews.AddAsync(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCompanyNewsAsync(CompanyNews news)
        {
            _dbContext.CompanyNews.Update(news);
            await _dbContext.SaveChangesAsync();
        }
    }
}
