using ICar.Data.Models;
using ICar.Data.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class CompanyValidatorTests
    {
        [Test]
        public void ValidateCompany_CompanyIsValid_ReturnsTrue()
        {
            Company company = new Company(1, "06.990.590/0001-23", "Google", "google@gmail.com",
                "hdjkas&765%", "Vancouver");
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.ValidateEntity(company);

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateCompany_CompanyIsInvalid_ReturnsFalse()
        {
            Company company = new Company(1, "06.990.590/0003", "aoogle", "google@.com",
                "hdjkas", "Vancouver");
            CompanyValidator cpValidator = new CompanyValidator();

            var result = cpValidator.ValidateEntity(company);

            Assert.That(result, Is.False);
        }
    }
}
