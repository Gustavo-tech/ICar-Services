using ICar.Data.Models.Entities.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Contracts
{
    public interface ICompanyNewsRepository
    {
        Task<List<CompanyNews>> GetCompanyNewsAsync();
        Task InsertCompanyNewsAsync(CompanyNews news);
        Task UpdateCompanyNewsAsync(CompanyNews news);
        Task DeleteCompanyNewsAsync(int id);
    }
}
