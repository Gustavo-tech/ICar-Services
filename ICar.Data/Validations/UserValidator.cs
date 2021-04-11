using ICar.Data.Models;
using ICar.Data.Models.System;
using ICar.Data.Validations.Abstracts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.Data.Validations
{
    public class UserValidator : EntityValidator<User>
    {
        private static bool ValidateCpf(string cpf)
        {
            string pattern = "[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}";
            return Regex.IsMatch(cpf, pattern);
        }

        public override List<InvalidReason> GetInvalidReasons(User user)
        {
            List<InvalidReason> invalidReasons = GetInvalids(user.Name, user.Email, user.Password);

            if (!ValidateCity(user.City))
                invalidReasons.Add(new InvalidReason
                (
                    "City is invalid",
                    "City should be capitalized"
                ));

            if (!ValidateCpf(user.Cpf))
                invalidReasons.Add(new InvalidReason
                (
                    "CPF is invalid",
                    "CPF should be valid and formatted"
                ));

            if (invalidReasons.Count > 0)
                return invalidReasons;

            return null;
        }

    }
}
