using ICar.API.Utilities.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.API.Validations
{
    public static class CarValidator
    {
        private static bool ValidatePlate(string plate)
        {
            string regExpression = "[A-Z]{0-3}[-][0-9]{4}";
            return Regex.IsMatch(plate, regExpression);
        }

        private static bool ValidateName(string maker)
        {
            return EntityValidatorUtilities.StringStartsWithAUpperCaseLetter(maker);
        }

        private static bool ValidateYear(int year)
        {
            int currentYear = DateTime.Now.Year;

            return year > currentYear - 100 && year <= currentYear;
        }

        private static bool ValidatePrice(double price)
        {
            return price > 1000;
        }

        private static bool ValidateColor(string color)
        {
            return color.Length > 2;
        }

        public static List<InvalidReason> ValidateCar(Car car)
        {
            List<InvalidReason> invalidReasons = new List<InvalidReason>();

            if (!ValidatePlate(car.Plate))
                invalidReasons.Add(new InvalidReason("Plate is invalid", "This plate is invalid"));

            if (!ValidateName(car.Model))
                invalidReasons.Add(new InvalidReason("Model is invalid", "This model doesn't start with a uppercase letter"));

            if (!ValidateName(car.Maker))
                invalidReasons.Add(new InvalidReason("Maker is invalid", "This maker doesn't start with a uppercase letter"));

            if (!ValidateYear(car.MakeDate))
                invalidReasons.Add(new InvalidReason("Make year is invalid", "This make year is invalid"));

            if (!ValidateYear(car.MakedDate))
                invalidReasons.Add(new InvalidReason("Maked year is invalid", "This maked year is invalid"));

            if (!ValidatePrice(car.Price))
                invalidReasons.Add(new InvalidReason("Price is invalid", "This price is less than a thousand reals"));

            //if (!ValidateColor(car.Color))
            //    invalidReasons.Add(new InvalidReason("Color is invalid", "This color is invalid"));

            if (!UserValidator.ValidateCpf(car.UserCpf))
                invalidReasons.Add(new InvalidReason("User is invalid", "This CPF is invalid"));

            if (!CompanyValidator.ValidateCnpj(car.CompanyCnpj))
                invalidReasons.Add(new InvalidReason("Company is invalid", "This CNPJ is invalid"));

            if (invalidReasons.Count == 0)
                return null;
            else
                return invalidReasons;
        }
    }
}
