using ICar.API.Validations;
using ICar.Data.ViewModels.Companies;
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
            NewCompany newCompany = new NewCompany("06.990.590/0001-23", "Google", "google@gmail.com",
                "hdjkas&765%", new List<string> { "Vancouver" });

            var result = CompanyValidator.GetInvalidReasonsForInsert(newCompany);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ValidateCompany_CompanyIsInvalid_ReturnsFalse()
        {
            NewCompany newCompany = new NewCompany("06.990.590/0003", "aoogle", "google@.com",
                "hdjkas", new List<string> { "vancouver" });

            var result = CompanyValidator.GetInvalidReasonsForInsert(newCompany);

            Assert.That(result, Is.Not.Null);
        }
    }
}
