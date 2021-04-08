﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Utilities.Validations
{
    public static class IdentityValidatorUtilities
    {
        public static bool StringStartsWithAUpperCaseLetter(string text)
        {
            if (text == null)
                throw new ArgumentNullException(text, "Text can't be null");

            string textUppercase = text.ToUpper();
            return text[0] == textUppercase[0];
        }

        public static bool StringContainsNumbers(string text)
        {
            if (text == null)
                throw new ArgumentNullException(text, "Text can't be null");

            string numbers = "0123456789";
            bool stringContainsNumbers = false;
            foreach(char ch in text)
            {
                foreach(char number in numbers)
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
    }
}
