using ICar.Data.Models;
using ICar.Data.Validations.Abstracts;
using System.Text.RegularExpressions;

namespace ICar.Data.Utilities.Validations
{
    public class UserValidator : EntityValidator<User>
    {
        private bool ValidateCpf(string cpf)
        {
            string reg = "[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0,9]{3}";
            return Regex.IsMatch(cpf, reg);
        }

        public override bool ValidateEntity(User user)
        {
            return ValidateName(user.Name) &&
                   ValidatePassword(user.Password) &&
                   ValidateCity(user.City) &&
                   ValidateCpf(user.Cpf);
        }
    }
}
