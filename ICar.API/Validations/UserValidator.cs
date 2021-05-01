using ICar.API.Validations.Abstracts;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.API.Validations
{
    public class UserValidator : EntityValidator<User, T>
    {
        public static bool ValidateCpf(string cpf)
        {
            string pattern = "[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}";
            return Regex.IsMatch(cpf, pattern);
        }

        public override List<InvalidReason> GetInvalidReasonsForInsert(User entity)
        {
            List<InvalidReason> invalidReasons = GetInvalids(entity.Name, entity.Email, entity.Password);

            if (!ValidateCity(entity.City))
                invalidReasons.Add(new InvalidReason
                (
                    "City is invalid",
                    "City should be capitalized"
                ));

            if (!ValidateCpf(entity.Cpf))
                invalidReasons.Add(new InvalidReason
                (
                    "CPF is invalid",
                    "CPF should be valid and formatted"
                ));

            if (invalidReasons.Count > 0)
                return invalidReasons;

            return null;
        }

        public override List<InvalidReason> GetInvalidReasonsForUpdate(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
