using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<News> GetNewsAsync(string id);
        Task<List<News>> GetNewsAsync();
        Task<List<News>> GetUserNewsAsync(string email);
    }
}
