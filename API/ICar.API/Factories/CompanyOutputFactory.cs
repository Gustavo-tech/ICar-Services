using ICar.Infrastructure.Database.Models;

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
                company.UserName,
                company.AccountCreationDate,
                AccountType = "company"
            };
        }
    }
}
