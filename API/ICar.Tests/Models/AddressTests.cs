using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
