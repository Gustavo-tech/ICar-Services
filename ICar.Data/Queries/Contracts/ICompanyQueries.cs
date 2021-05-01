using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyQueries
    {
        List<CompanyInSystem> GetCompanies(int? quantity = null);
        CompanyInSystem GetCompanyByEmail(string email);
        CompanyInSystem GetCompanyByCnpj(string cnpj);
        void InsertCompany(Company company, bool isAdmin = false);
    }
}
