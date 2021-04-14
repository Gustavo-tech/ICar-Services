using ICar.Data.Models;
using ICar.Data.Validations;
using NUnit.Framework;
using System.Collections.Generic;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class CompanyValidatorTests
    {
        [Test]
        public void GetInvalidReasons_CompanyIsValid_ReturnsTrue()
        {
            Company company = new Company("06.990.590/0001-23", "Google", "google@gmail.com",
                "hdjkas&765%", new List<string> { "Vancouver" });
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.GetInvalidReasons(company);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ValidateCompany_CompanyIsInvalid_ReturnsFalse()
        {
            Company company = new Company("06.990.590/0003", "aoogle", "google@.com",
                "hdjkas", null);
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.GetInvalidReasons(company);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
