using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.Companies;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyQueries
    {
        List<Company> GetCompanies(int? quantity = null);
        Company GetCompanyByEmail(string email);
        Company GetCompanyByCnpj(string cnpj);
        void InsertCompany(NewCompany company, bool isAdmin = false);
    }
}
