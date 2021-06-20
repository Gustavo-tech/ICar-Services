using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Generators
{
    public static class CompanyOutputFactory
    {
        public static dynamic GenerateCompanyOutput(Company company)
        {
            return new
            {
                CNPJ = company.Cnpj,
                company.Email,
                company.Name,
                company.AccountCreationDate,
                AccountType = "company"
            };
        }
    }
}
