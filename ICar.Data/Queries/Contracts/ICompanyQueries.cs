using ICar.Data.Models;
using System.Collections.Generic;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyQueries
    {
        List<Company> GetCompanies(int? quantity = null);
        Company GetCompanyByEmail(string email);
        void InsertCompany(Company company, bool isAdmin);
    }
}
