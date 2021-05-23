using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.News
{
    public class UserNewsRepository : INewsRepository<UserNews>
    {
        private readonly DatabaseContext _dbContext;

        public UserNewsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserNews>> GetNewsAsync()
        {
            return await _dbContext.UserNews.ToListAsync();
        }

        public async Task InsertNewsAsync(UserNews UserNews)
        {
            await _dbContext.UserNews.AddAsync(UserNews);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNewsAsync(UserNews UserNews)
        {
            _dbContext.UserNews.Update(UserNews);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNewsAsync(int id)
        {
            UserNews UserNews = _dbContext.UserNews.Where(x => x.Id == id).FirstOrDefault();

            if (UserNews != null)
            {
                _dbContext.UserNews.Remove(UserNews);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
