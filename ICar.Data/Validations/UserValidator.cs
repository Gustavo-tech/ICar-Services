using ICar.Data.Models;
using ICar.Data.Utilities.Validations;
using ICar.Data.Validations.Abstracts;
using System;
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

        public override bool ValidateEntity(User user)
        {
            return ValidateName(user.Name) &&
                   ValidateEmail(user.Email) &&
                   ValidatePassword(user.Password) &&
                   ValidateCity(user.City) &&
                   ValidateCpf(user.Cpf);
        }
    }
}
