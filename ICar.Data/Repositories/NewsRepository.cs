using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<News>> GetCompanyNewsAsync()
        {
            return await _dbContext.News.Where(x => x.CompanyCnpj != null).ToListAsync();
        }

        public async Task<News> GetCompanyNewsAsync(int id)
        {
            return await _dbContext.News.FindAsync(id);
        }

        public async Task<List<News>> GetCompanyNewsAsync(string companyCnpj)
        {
            return await _dbContext.News.Where(x => x.CompanyCnpj == companyCnpj).ToListAsync();
        }

        public async Task<News> GetCompanyNewsAsync(string title, string text)
        {
            return await _dbContext.News
                .Where(x => x.Title == title && x.Text == text).FirstOrDefaultAsync();
        }

        public async Task<List<News>> GetUserNewsAsync()
        {
            return await _dbContext.News.Where(x => x.UserCpf != null).ToListAsync();
        }
    }
}
