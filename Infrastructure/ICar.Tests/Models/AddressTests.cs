using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    class AddressTests
    {
        [Test]
        public async Task TestBuildAddress_AddressIsValid_ShouldBuildAddress()
        {
            string zipCode = "07623210";
            string district = "Samambaia";
            string location = "Mairiporã";
            string street = "Rua Dezessete";

            Address address = await Address.BuildAddress(zipCode, location, district, street);
            Assert.IsNotNull(address);
        }

        [Test]
        [Repeat(10)]
        public void TestBuildAddress_AddressIsInvalid_ShouldThrowAnException()
        {
            string zipCode = "07623210";
            string ramdomId = Guid.NewGuid().ToString("N");

            Assert.CatchAsync<Exception>(async () => await Address.BuildAddress(zipCode, ramdomId, ramdomId, ramdomId));
        }
    }
}
