using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.News
{
    public class CompanyNewsRepository : INewsRepository<CompanyNews>
    {
        private readonly DatabaseContext _dbContext;

        public CompanyNewsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteNewsAsync(int id)
        {
            CompanyNews cn = await _dbContext.CompanyNews.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (cn != null)
            {
                _dbContext.CompanyNews.Remove(cn);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyNews>> GetNewsAsync()
        {
            return await _dbContext.CompanyNews.ToListAsync();
        }

        public async Task InsertNewsAsync(CompanyNews news)
        {
            await _dbContext.CompanyNews.AddAsync(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(CompanyNews news)
        {
            _dbContext.CompanyNews.Update(news);
            await _dbContext.SaveChangesAsync();
        }
    }
}
