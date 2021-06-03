using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Generators
{
    public static class CompanyOutputGenerator
    {
        public static dynamic GenerateCompanyOutput(Company company)
        {
            return new
            {
                CNPJ = company.Cnpj,
                company.Email,
                company.Name,
                company.AccountCreationDate,
                Cities = company.Cities.Select(x => x.Name).ToList(),
                CompanyLogins = company.CompanyLogins.Select(x => x.Time),
                CompanyNews = company.CompanyNews.Select(x => new
                {
                    x.Text,
                    x.Title,
                    x.LastUpdate,
                    x.CreatedOn
                })
            };
        }
    }
}
