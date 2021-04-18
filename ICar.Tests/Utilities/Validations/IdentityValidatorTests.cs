using ICar.Data.Utilities.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Utilities.Validations {
    [TestFixture]
    class IdentityValidatorTests {
        [Test]
        [TestCase("Vancouver")]
        [TestCase("Valinhos")]
        [TestCase("Santos")]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsValid_ReturnsTrue(string text) {
            var result = EntityValidatorUtilities.StringStartsWithAUpperCaseLetter(text);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("vancouver")]
        [TestCase("valinhos")]
        [TestCase("santos")]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsInvalid_ReturnsFalse(string text) {
            var result = EntityValidatorUtilities.StringStartsWithAUpperCaseLetter(text);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestStringStartsWithAUpperCaseLetter_ArgumentsIsNull_ThrowException() {
            Assert.That(() => EntityValidatorUtilities.StringStartsWithAUpperCaseLetter(null),
                Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("asda890890")]
        [TestCase("2fastforyou")]
        [TestCase("b2b")]
        [TestCase("ewq9e89wq0e8qw")]
        public void TestStringContainsNumber_StringContainsNumber_ReturnsTrue(string text) {
            var result = EntityValidatorUtilities.StringContainsNumbers(text);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("asda")]
        [TestCase("fastforyou")]
        [TestCase("bbb")]
        [TestCase("ewqewqeqw")]
        public void TestStringContainsNumber_StringDoesntContainNumber_ReturnsFalse(string text) {
            var result = EntityValidatorUtilities.StringContainsNumbers(text);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("asda890890", 5)]
        [TestCase("asda890890", 4)]
        [TestCase("2fastforyou", 1)]
        [TestCase("b2b", 1)]
        public void TestStringContainsNumber_StringContainsEnoughNumbers_ReturnsTrue(string text, int quantity) {
            var result = EntityValidatorUtilities.StringContainsNumbers(text, quantity);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("asda123", 4)]
        [TestCase("fastforyou", 1)]
        [TestCase("bbb32132", 6)]
        public void TestStringContainsNumber_StringDoesntContainEnoughNumbers_ReturnsFalse(string text, int quantity) {
            var result = EntityValidatorUtilities.StringContainsNumbers(text, quantity);

            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("aaa*bbb")]
        [TestCase("!!abc")]
        [TestCase("%123")]
        public void TestStringContainsSpecialChar_StringContainsASpecialChar_ReturnsTrue(string text) {
            var result = EntityValidatorUtilities.StringContainsASpecialChar(text);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("aaabbb")]
        [TestCase("abc")]
        [TestCase("123")]
        public void TestStringContainsSpecialChar_StringDoesntContainASpecialChar_ReturnsFalse(string text) {
            var result = EntityValidatorUtilities.StringContainsASpecialChar(text);

            Assert.That(result, Is.False);
        }
    }
}
