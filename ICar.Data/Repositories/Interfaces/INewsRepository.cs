using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetCompanyNewsAsync();
        Task<List<News>> GetUserNewsAsync();
    }
}
