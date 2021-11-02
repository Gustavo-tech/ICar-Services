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
    class CarPictureTests
    {
        [Test]
        public void TestConstructor_ConstructorIsValid_InstantiateACarPicture()
        {
            CarPicture cp = new("base64; 87879789", new Car());

            Assert.IsNotNull(cp);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void TestConstructor_ConstructorIsInvalid_ThrowException(string picture)
        {
            Assert.Catch<Exception>(() => new CarPicture(picture, new Car()));
        }
    }
}
