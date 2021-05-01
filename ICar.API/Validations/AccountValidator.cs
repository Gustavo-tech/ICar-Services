using ICar.API.Utilities.Validations;
using ICar.Data.Models.Abstracts;
using ICar.Data.Models.System;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace ICar.API.Validations
{
    public static class AccountValidator
    {
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length > 1;
        }

        public static bool ValidateEmail(string email)
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

        public static bool ValidateCity(string city)
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

        public static bool ValidatePassword(string password)
        {
            return password.Length > 7 &&
                   EntityValidatorUtilities.StringContainsNumbers(password) &&
                   EntityValidatorUtilities.StringContainsASpecialChar(password);
        }

        public static List<InvalidReason> GetInvalids(Entity entity)
        {
            List<InvalidReason> invalidReasons = new List<InvalidReason>();

            if (!ValidateName(entity.Name))
                invalidReasons.Add(new InvalidReason
                (
                    "Name is invalid",
                    "Name can't be empty and it should have more than one character"
                ));

            if (!ValidateEmail(entity.Email))
                invalidReasons.Add(new InvalidReason
                (
                    "Email is invalid",
                    "Email is invalid, check your email"
                ));

            if (!ValidatePassword(entity.Password))
                invalidReasons.Add(new InvalidReason
                (
                    "Password is invalid",
                    "Password should contain more than seven chars, at least one number and at least one special char"
                ));

            return invalidReasons;
        }
    }
}
