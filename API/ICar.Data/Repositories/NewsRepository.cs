using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
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

        public async Task<News> GetNewsAsync(int id)
        {
            return await _dbContext.News.FindAsync(id);
        }

        public async Task<News> GetNewsAsync(string title, string text)
        {
            return await _dbContext.News
                .Where(x => x.Title == title && x.Text == text).FirstOrDefaultAsync();
        }

        public async Task<List<News>> GetUserNewsAsync()
        {
            return await _dbContext.News
                .ToListAsync();
        }

        public async Task<List<News>> GetUserNewsAsync(string email)
        {
            return await _dbContext.News
                .Where(x => x.Owner.Email == email)
                .ToListAsync();
        }
    }
}
