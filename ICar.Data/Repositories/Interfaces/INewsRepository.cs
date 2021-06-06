using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetCompanyNewsAsync();
        Task<List<News>> GetCompanyNewsAsync(string companyCnpj);
        Task<News> GetCompanyNewsAsync(string title, string text);
        Task<List<News>> GetUserNewsAsync();
    }
}
