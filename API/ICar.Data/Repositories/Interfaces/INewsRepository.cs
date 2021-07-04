using ICar.Infrastructure.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Database.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetCompanyNewsAsync();
        Task<News> GetNewsAsync(int id);
        Task<News> GetNewsAsync(string title, string text);
        Task<List<News>> GetCompanyNewsAsync(string companyCnpj);
        Task<List<News>> GetUserNewsAsync();
        Task<List<News>> GetUserNewsAsync(string userCpf);

    }
}
