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
                CompanyLogins = company.Logins.Select(x => x.Time),
                CompanyNews = company.News.Select(x => new
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
