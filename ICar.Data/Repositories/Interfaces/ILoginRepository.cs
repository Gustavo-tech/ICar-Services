using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAllLogins();
    }
}
