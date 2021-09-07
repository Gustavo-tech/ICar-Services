using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    public class CityTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void TestCityConstructor_WhenCalledWithEmptyName_ThrowsAnException(string cityName)
        {
            Assert.Throws<ArgumentNullException>(() => new City(cityName));
        }
    }
}
