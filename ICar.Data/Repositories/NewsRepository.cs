using ICar.Data.Models.Entities;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
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

        public async Task InsertNewsAsync(News news)
        {
            await _dbContext.News.AddAsync(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(News news)
        {
            _dbContext.News.Update(news);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(int id)
        {
            News news = _dbContext.News.Where(x => x.Id == id).FirstOrDefault();

            if (news != null)
            {
                _dbContext.News.Remove(news);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
