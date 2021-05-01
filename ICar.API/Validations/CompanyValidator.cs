using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.API.Validations
{
    public class CompanyValidator
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
                if (!AccountValidator.ValidateCity(city))
                    return false;
            }

            return true;
        }

        public List<InvalidReason> GetInvalidReasonsForInsert(Company company)
        {
            List<InvalidReason> invalidReasons = AccountValidator.GetInvalids(company);

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
