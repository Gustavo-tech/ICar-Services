using ICar.Infrastructure.Database.Converter;
using ICar.Infrastructure.Database.Models.Enums.Car;
using NUnit.Framework;

namespace ICar.Tests.Converters
{

    [TestFixture]
    class CarPropertiesConverterTests
    {

        [Test]
        public void TestConvertByteToBool_BitIsOne_ReturnsTrue()
        {
            var result = CarPropertyConverter.ConvertByteToBool(1);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestConvertByteToBool_BitIsZero_ReturnsFalse()
        {
            var result = CarPropertyConverter.ConvertByteToBool(0);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestConvertBoolToBit_BooleanIsTrue_ReturnsOne()
        {
            var result = CarPropertyConverter.ConvertBoolToBit(true);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestConvertBoolToBit_BooleanIsFalse_ReturnsZero()
        {
            var result = CarPropertyConverter.ConvertByteToBool(0);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestConvertWhiteStringToEnum_WhenCalled_ReturnsWhiteEnum()
        {
            var result = CarPropertyConverter.ConvertStringToColor("White");

            Assert.AreEqual(result, Color.White);
        }

        [Test]
        public void TestConvertWhiteEnumToString_WhenCalled_ReturnsWhiteString()
        {
            var result = CarPropertyConverter.ConvertColorToString(Color.White);

            Assert.AreEqual(result, "White");
        }

        [Test]
        public void TestConvertGasolineTypeToString_WhenCalled_ReturnsGasString()
        {
            GasolineType gasType = GasolineType.Gasoline;

            var result = CarPropertyConverter.ConvertGasolineTypeToString(gasType);

            Assert.That(result, Is.EqualTo("Gas"));
        }

        [Test]
        public void TestConvertStringToGasolineType_WhenCalled_ReturnsGasolineType()
        {
            string gasType = "Gas";

            var result = CarPropertyConverter.ConvertStringToGasolineType(gasType);

            Assert.That(result, Is.EqualTo(GasolineType.Gasoline));
        }
    }
}
