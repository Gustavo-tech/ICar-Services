using ICar.Infrastructure.Database.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ICarContext _dbContext;

        public BaseRepository(ICarContext dbContext)
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
