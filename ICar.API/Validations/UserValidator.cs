﻿using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.API.Validations
{
    public class UserValidator
    {
        public static bool ValidateCpf(string cpf)
        {
            string pattern = "[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}";
            return Regex.IsMatch(cpf, pattern);
        }

        public List<InvalidReason> GetInvalidReasonsForInsert(User user)
        {
            List<InvalidReason> invalidReasons = AccountValidator.GetInvalids(user);

            if (!AccountValidator.ValidateCity(user.City))
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
