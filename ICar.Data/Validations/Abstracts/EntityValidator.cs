using ICar.Data.Models.Abstract;
using ICar.Data.Utilities.Validations;
using System;

namespace ICar.Data.Validations.Abstracts
{
    public abstract class EntityValidator<T>
    {
        protected bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 1;
        }

        protected bool ValidateCity(string city)
        {
            try
            {
                return EntityValidatorUtilities.StringStartsWithAUpperCaseLetter(city) &&
                       city.Length > 1;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        protected bool ValidatePassword(string password)
        {
            return password.Length > 7 &&
                   EntityValidatorUtilities.StringContainsNumbers(password) &&
                   EntityValidatorUtilities.StringContainsASpecialChar(password);
        }

        public abstract bool ValidateEntity(T entity);
    }
}
