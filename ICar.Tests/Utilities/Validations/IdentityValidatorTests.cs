using ICar.Data.Utilities.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Utilities.Validations
{
    [TestFixture]
    class IdentityValidatorTests
    {
        [Test]
        [TestCase("Vancouver")]
        [TestCase("Valinhos")]
        [TestCase("Santos")]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsValid_ReturnsTrue(string text)
        {
            var result = IdentityValidatorUtilities.StringStartsWithAUpperCaseLetter(text);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("vancouver")]
        [TestCase("valinhos")]
        [TestCase("santos")]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsInvalid_ReturnsFalse(string text)
        {
            var result = IdentityValidatorUtilities.StringStartsWithAUpperCaseLetter(text);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsNull_ThrowException()
        {
            Assert.That(() => IdentityValidatorUtilities.StringStartsWithAUpperCaseLetter(null),
                Throws.ArgumentNullException);
        }
    }
}
