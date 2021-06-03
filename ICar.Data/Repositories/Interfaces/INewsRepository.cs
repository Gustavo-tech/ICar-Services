using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface INewsRepository<T>
    {
        Task<List<T>> GetNewsAsync();
    }
}
