using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ILoginRepository<T>
    {
        Task<List<T>> GetAllLogins();
    }
}
