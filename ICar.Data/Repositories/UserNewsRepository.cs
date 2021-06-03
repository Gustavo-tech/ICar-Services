using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Repositories
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
    }
}
