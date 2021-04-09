using ICar.Data.Utilities.Validations;
using System;
using System.Net.Mail;

namespace ICar.Data.Validations.Abstracts
{
    public abstract class EntityValidator<T>
    {
        protected static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 1;
        }

        protected static bool ValidateCity(string city)
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

        protected static bool ValidateEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected static bool ValidatePassword(string password)
        {
            return password.Length > 7 &&
                   EntityValidatorUtilities.StringContainsNumbers(password) &&
                   EntityValidatorUtilities.StringContainsASpecialChar(password);
        }

        public abstract bool ValidateEntity(T entity);
    }
}
