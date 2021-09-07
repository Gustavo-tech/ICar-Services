using ICar.Infrastructure.Models;
using ICar.Infrastructure.Models.Enums.Car;
using NUnit.Framework;

namespace ICar.Tests.Converters
{

    [TestFixture]
    class CarTests
    {

        [Test]
        public void TestConvertGasolineTypeToString_WhenCalled_ReturnsGasString()
        {
            GasolineType gasType = GasolineType.Gasoline;

            var result = Car.ConvertGasolineTypeToString(gasType);

            Assert.That(result, Is.EqualTo("gasoline"));
        }

        [Test]
        public void TestConvertStringToGasolineType_WhenCalled_ReturnsGasolineType()
        {
            string gasType = "gasoline";

            var result = Car.ConvertStringToGasolineType(gasType);

            Assert.That(result, Is.EqualTo(GasolineType.Gasoline));
        }
    }
}
