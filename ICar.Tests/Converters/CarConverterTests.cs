using ICar.Data.Converter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Converters {

    [TestFixture]
    class CarConverterTests {

        [Test]
        public void TestConvertByteToBool_BitIsOne_ReturnsTrue() {
            var result = CarPropertyConverter.ConvertByteToBool(1);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestConvertByteToBool_BitIsZero_ReturnsFalse() {
            var result = CarPropertyConverter.ConvertByteToBool(0);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestConvertBoolToBit_BooleanIsTrue_ReturnsOne() {
            var result = CarPropertyConverter.ConvertBoolToBit(true);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestConvertBoolToBit_BooleanIsFalse_ReturnsZero() {
            var result = CarPropertyConverter.ConvertByteToBool(0);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
