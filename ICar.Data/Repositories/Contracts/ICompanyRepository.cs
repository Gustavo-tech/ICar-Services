using ICar.Data.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByEmailAsync(string email);
        Task<Company> GetCompanyByCnpjAsync(string cnpj);
        Task InsertCompany(Company company);
    }
}
