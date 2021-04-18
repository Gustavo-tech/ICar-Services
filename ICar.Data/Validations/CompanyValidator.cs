using ICar.Data.Models;
using ICar.Data.Models.System;
using ICar.Data.Validations.Abstracts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.Data.Validations {
    public class CompanyValidator : EntityValidator<Company> {
        private static bool ValidateCnpj(string cnpj) {
            string pattern = "[0-9]{2}.[0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}";
            return Regex.IsMatch(cnpj, pattern);
        }

        private static bool ValidateCities(List<string> cities) {
            foreach (string city in cities) {
                if (!ValidateCity(city))
                    return false;
            }

            return true;
        }

        public override List<InvalidReason> GetInvalidReasons(Company company) {
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
