using System;

namespace ICar.API.Utilities.Validations
{
    public static class EntityValidatorUtilities
    {
        public static bool StringStartsWithAUpperCaseLetter(string text)
        {
            if (text == null)
                throw new ArgumentNullException(text, "Text can't be null");

            return text.StartsWith(text.Remove(1, text.Length - 1).ToUpper());
        }

        public static bool StringContainsNumbers(string text)
        {
            if (text == null)
                throw new ArgumentNullException(text, "Text can't be null");

            string numbers = "0123456789";
            bool stringContainsNumbers = false;
            foreach (char ch in text)
            {
                foreach (char number in numbers)
                {
                    if (ch == number)
                    {
                        stringContainsNumbers = true;
                        break;
                    }
                }

                if (stringContainsNumbers)
                    break;
            }

            return stringContainsNumbers;
        }

        public static bool StringContainsNumbers(string text, int quantity)
        {
            if (text == null)
                throw new ArgumentNullException(text, "Text can't be null");

            string numbers = "0123456789";
            int numbersQuantity = 0;
            foreach (char ch in text)
            {
                foreach (char number in numbers)
                {
                    if (ch == number)
                    {
                        numbersQuantity += 1;
                    }
                }

                if (numbersQuantity >= quantity)
                    break;

            }

            return numbersQuantity >= quantity;
        }

        public static bool StringContainsASpecialChar(string text)
        {
            string specialChars = "!#$%&'()*+,-./:;<=>?@[]^_`{|}~";
            text = text.ToLower();

            bool stringContainsSpecialChar = false;
            foreach (char ch in text)
            {
                foreach (char specChar in specialChars)
                {
                    if (ch.Equals(specChar))
                    {
                        stringContainsSpecialChar = true;
                        break;
                    }
                }
                if (stringContainsSpecialChar)
                    break;
            }

            return stringContainsSpecialChar;
        }
    }
}
