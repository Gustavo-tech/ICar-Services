﻿using ICar.Data.Models.Entities.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Data.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByEmailAsync(string email);
        Task<Company> GetCompanyByCnpjAsync(string cnpj);
        Task InsertCompany(Company company);
    }
}