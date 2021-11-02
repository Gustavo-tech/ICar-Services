using ICar.Infrastructure.Models;
using ICar.Infrastructure.Models.Enums.Car;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
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

        [Test]
        [TestCase("automatic", ExchangeType.Automatic)]
        [TestCase("Automatic", ExchangeType.Automatic)]
        [TestCase("manual", ExchangeType.Manual)]
        public void TestConvertStringToTypeOfExchange_StringIsRecognized_ReturnCorrectTypeOfExchange(string type, ExchangeType exType)
        {
            ExchangeType result = Car.ConvertStringToTypeOfExchange(type);

            Assert.AreEqual(exType, result);
        }

        [Test]
        [TestCase("Automatic car")]
        [TestCase("Manual car")]
        public void TestConvertStringToTypeOfExchange_StringIsNotRecognized_ThrowException(string type)
        {
            Assert.Catch<Exception>(() => Car.ConvertStringToTypeOfExchange(type));
        }

        [Test]
        [TestCase(ExchangeType.Automatic, "automatic")]
        [TestCase(ExchangeType.Manual, "manual")]
        public void TestTypeOfExchangeToString_WhenCalled_ReturnsCorrectString(ExchangeType type, string expected)
        {
            string result = Car.ConvertTypeOfExchangeToString(type);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestIncrementNumberOfViews_WhenCalled_IncreaseViewsNumber()
        {
            Car car = new() { };

            car.IncreaseNumberOfViews();

            Assert.AreEqual(1, car.NumberOfViews);
        }
    }
}
