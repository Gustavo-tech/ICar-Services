using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface INewsRepository<T>
    {
        Task<List<T>> GetNewsAsync();
        Task InsertNewsAsync(T news);
        Task UpdateNewsAsync(T news);
        Task DeleteNewsAsync(int id);
    }
}
