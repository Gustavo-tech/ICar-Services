using System;
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
    }
}
