using ICar.Data.Models;
using ICar.Data.Validations.Abstracts;
using System.Text.RegularExpressions;

namespace ICar.Data.Validations
{
    public class CompanyValidator : EntityValidator<Company>
    {
        private bool ValidateCnpj(string cnpj)
        {
            string pattern = "[0-9]{2}.[0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}";
            return Regex.IsMatch(cnpj, pattern);
        }

        public override bool ValidateEntity(Company company)
        {
            return ValidateName(company.Name) &&
                   ValidatePassword(company.Password) &&
                   ValidateCity(company.City) &&
                   ValidateCnpj(company.Cnpj);
        }
    }
}
