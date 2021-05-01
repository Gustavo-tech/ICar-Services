using ICar.API.Validations.Abstracts;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.API.Validations
{
    public class CompanyValidator : EntityValidator<Company, T>
    {
        public static bool ValidateCnpj(string cnpj)
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

        public override List<InvalidReason> GetInvalidReasonsForInsert(Company company)
        {
            List<InvalidReason> invalidReasons = GetInvalids(company.Name, company.Email, company.Password);

            if (!ValidateCities(company.Cities))
                invalidReasons.Add(new InvalidReason
                (
                    "Cities is invalid",
                    "One or more cities is invalid, it should be capitalized"
                ));


            if (!ValidateCnpj(company.Cnpj))
                invalidReasons.Add(new InvalidReason
                (
                    "CNPJ is invalid",
                    "This CNPJ is invalid, it should be formatted"
                ));

            if (invalidReasons.Count > 0)
                return invalidReasons;
            else
                return null;
        }
    }
}
