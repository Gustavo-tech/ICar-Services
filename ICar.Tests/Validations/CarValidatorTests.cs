using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Enums.Car;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class CarValidatorTests
    {
        [Test]
        public void TestValidateCar_CarIsValid_ReturnsNull()
        {
            Car car = new Car("GHJ-9089", "Chevrolet", "Onix", 2019, 2020, 45.800, TypeOfExchange.Manual,
                48000, Color.Black, false, true, true, GasolineType.GasolineAndDiesel, false, "", "Vinhedo",
                "708.568.907-78", "");

            var result = CarValidator.ValidateCar(car);

            Assert.IsNull(result);
        }

        [Test]
        public void TestValidateCar_CarIsInvalid_ReturnsAList()
        {
            Car car = new Car("GHJ-90", "chevret", "anix", 2019, 2020, 45.800, TypeOfExchange.Manual,
                48000, Color.Black, false, true, true, GasolineType.GasolineAndDiesel, false, "", "cinhedo",
                "708.56", "3232");

            var result = CarValidator.ValidateCar(car);

            Assert.IsNotNull(result);
        }
    }
}
