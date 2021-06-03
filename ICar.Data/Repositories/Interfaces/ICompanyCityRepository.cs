using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface ICompanyCityRepository
    {
        Task<List<CompanyCity>> GetCompanyCitiesAsync();
        Task<List<CompanyCity>> GetCompanyCitiesAsync(string cnpj);
        Task<List<CompanyCity>> GetCompanyCitiesAsync(int cityId);
        Task<CompanyCity> GetCompanyCityAsync(string cnpj, int cityId);
    }
}
