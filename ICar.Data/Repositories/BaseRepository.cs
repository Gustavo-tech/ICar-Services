using ICar.Data;
using ICar.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DatabaseContext _dbContext;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync<T>(T t)
        {
            _dbContext.Add(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T t)
        {
            _dbContext.Remove(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T t)
        {
            _dbContext.Update(t);
            await _dbContext.SaveChangesAsync();
        }
    }
}
