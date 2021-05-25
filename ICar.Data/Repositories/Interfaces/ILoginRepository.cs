using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ILoginRepository<T>
    {
        Task<List<T>> GetAllLogins();
        Task AddLogin(T t);
    }
}
