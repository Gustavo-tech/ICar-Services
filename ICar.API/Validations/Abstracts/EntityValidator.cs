using ICar.API.Utilities.Validations;
using ICar.Data.Models.System;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace ICar.API.Validations.Abstracts
{
    public abstract class EntityValidator<T, U>
    {
        protected static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 1;
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

        protected static bool ValidatePassword(string password)
        {
            return password.Length > 7 &&
                   EntityValidatorUtilities.StringContainsNumbers(password) &&
                   EntityValidatorUtilities.StringContainsASpecialChar(password);
        }

        protected static List<InvalidReason> GetInvalids(string name, string email, string password)
        {
            List<InvalidReason> invalidReasons = new List<InvalidReason>();

            if (!ValidateName(name))
                invalidReasons.Add(new InvalidReason
                (
                    "Name is invalid",
                    "Name can't be empty and it should have more than one character"
                ));

            if (!ValidateEmail(email))
                invalidReasons.Add(new InvalidReason
                (
                    "Email is invalid",
                    "Email is invalid, check your email"
                ));

            if (!ValidatePassword(password))
                invalidReasons.Add(new InvalidReason
                (
                    "Password is invalid",
                    "Password should contain more than seven chars, at least one number and at least one special char"
                ));

            return invalidReasons;
        }

        public abstract List<InvalidReason> GetInvalidReasonsForInsert(T entity);
        public abstract List<InvalidReason> GetInvalidReasonsForUpdate(U entity);
    }
}
