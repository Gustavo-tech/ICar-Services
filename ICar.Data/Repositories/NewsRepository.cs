using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext _dbContext;

        public NewsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<News>> GetNewsAsync()
        {
            return await _dbContext.News.ToListAsync();
        }
    }
}
