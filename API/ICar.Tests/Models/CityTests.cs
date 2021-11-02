using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    [TestFixture]
    class CityTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TestCityConstructor_WhenCalledWithEmptyName_ThrowsAnException(string cityName)
        {
            Assert.Throws<ArgumentNullException>(() => new City(cityName));
        }

        [Test]
        [TestCase("Campinas")]
        [TestCase("Valinhos")]
        [TestCase("Vinhedo")]
        public void TestCityConstructor_WhenCalledWithValidArguments_ConstructACity(string name)
        {
            City city = new(name);

            Assert.IsNotNull(city);
        }
    }
}
