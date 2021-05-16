using ICar.API.Validations;
using ICar.Data.ViewModels.Cars;
using NUnit.Framework;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class CarValidatorTests
    {
        [Test]
        public void TestValidateCar_CarIsValid_ReturnsNull()
        {
            NewCar car = new NewCar("GHJ-9089", "Chevrolet", "Onix", 2019, 2020, 45.800, "man",
                48000, "Black", false, true, true, "Gasoline", false, "", "Vinhedo",
                "708.568.907-78", "");

            var result = CarValidator.ValidateNewCar(car);

            Assert.IsNull(result);
        }

        [Test]
        public void TestValidateCar_CarIsInvalid_ReturnsAList()
        {
            NewCar car = new NewCar("GHJ-90", "chevret", "anix", 2019, 2020, 45.800, "man",
                48000, "bla", false, true, true, "Die", false, "", "cinhedo",
                "708.56", "3232");

            var result = CarValidator.ValidateNewCar(car);

            Assert.IsNotNull(result);
        }
    }
}
