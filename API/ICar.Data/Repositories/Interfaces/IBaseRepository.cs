using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task AddAsync<T>(T t);
        Task UpdateAsync<T>(T t);
        Task DeleteAsync<T>(T t);
    }
}
