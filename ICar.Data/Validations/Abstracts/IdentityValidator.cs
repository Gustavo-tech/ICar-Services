using ICar.Data.Utilities.Validations;
using System;
using System.Text.RegularExpressions;

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
    }
}
