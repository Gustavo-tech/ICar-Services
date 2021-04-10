using ICar.Data.Models;
using ICar.Data.Validations.Abstracts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.Data.Validations
{
    public class CompanyValidator : EntityValidator<Company>
    {
        private static bool ValidateCnpj(string cnpj)
        {
            string pattern = "[0-9]{2}.[0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}";
            return Regex.IsMatch(cnpj, pattern);
        }

        private static bool ValidateCities(List<string> cities)
        {
            foreach (string city in cities)
            {
                if (!ValidateCity(city))
                    return false;
            }

            return true;
        }

        public override bool ValidateEntity(Company company)
        {
            return ValidateName(company.Name) &&
                   ValidateEmail(company.Email) &&
                   ValidatePassword(company.Password) &&
                   ValidateCities(company.Cities) &&
                   ValidateCnpj(company.Cnpj);
        }
    }
}
