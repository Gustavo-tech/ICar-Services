﻿using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.Companies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Queries.Contracts
{
    public interface ICompanyQueries
    {
        Task<List<Company>> GetCompanies(int? quantity = null);
        Task<Company> GetCompanyByEmail(string email);
        Task<Company> GetCompanyByCnpj(string cnpj);
        Task InsertCompany(NewCompany company, bool isAdmin = false);
    }
}
