using ICar.API.Validations;
using ICar.Data.Models.Entities;
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
            Company newCompany = new Company("06.990.590/0001-23", "Google", "google@gmail.com",
                "hdjkas&765%", new List<string> { "Vancouver" });
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.GetInvalidReasonsForInsert(newCompany);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ValidateCompany_CompanyIsInvalid_ReturnsFalse()
        {
            Company newCompany = new Company("06.990.590/0003", "aoogle", "google@.com",
                "hdjkas", new List<string> { "vancouver" });
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.GetInvalidReasonsForInsert(newCompany);

            Assert.That(result, Is.Not.Null);
        }
    }
}
