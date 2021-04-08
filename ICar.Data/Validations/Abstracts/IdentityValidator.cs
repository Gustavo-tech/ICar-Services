using ICar.Data.Utilities.Validations;
using System;

namespace ICar.Data.Validations.Abstracts
{
    internal abstract class IdentityValidator
    {
        private bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 1;
        }

        private bool ValidateCity(string city)
        {
            try
            {
                return IdentityValidatorUtilities.StringStartsWithAUpperCaseLetter(city) &&
                       city.Length > 1;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        private bool ValidatePassword(string password)
        {
            return password.Length > 7 &&
                   IdentityValidatorUtilities.StringContainsNumbers(password) &&
                   IdentityValidatorUtilities.StringContainsASpecialChar(password);
        }
    }
}
