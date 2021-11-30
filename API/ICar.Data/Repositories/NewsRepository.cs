using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ICarContext _dbContext;

        public NewsRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<News> GetNewsAsync(string id)
        {
            return await _dbContext.News.FindAsync(id);
        }

        public async Task<List<News>> GetNewsAsync()
        {
            return await _dbContext.News
                .Include(x => x.Owner)
                .OrderBy(x => x.LastUpdate)
                .ToListAsync();
        }

        public async Task<List<News>> GetNewsByEmail(string email)
        {
            return await _dbContext.News
                .Where(x => x.Owner.Email == email)
                .Include(x => x.Owner)
                .OrderBy(x => x.LastUpdate)
                .ToListAsync();
        }
    }
}
