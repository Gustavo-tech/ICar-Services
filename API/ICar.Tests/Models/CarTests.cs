using ICar.Infrastructure.Models;
using ICar.Infrastructure.Models.Enums.Car;
using ICar.Infrastructure.ViewModels.Input.Car;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Tests.Models
{
    class CarTests
    {
        private Car _car;
        private User _owner;

        [SetUp]
        public void SetUp()
        {
            _owner = new("Gustavo", "(19) 99876-0982", "gustavo@gmail.com", "admin");

            _car = new("JKH-9087", "Ford", "Mustang", 2020, 2021, 2000, 350000,
                "This car has a nice sound", "#FFFFF", ExchangeType.Manual, GasolineType.Gasoline,
                _owner, null, new string[] { "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBUVF" });
        }

        [Test]
        public void TestConvertGasolineTypeToString_WhenCalled_ReturnsGasolineString()
        {
            GasolineType gasType = GasolineType.Gasoline;

            var result = Car.ConvertGasolineTypeToString(gasType);

            Assert.That(result, Is.EqualTo("gasoline"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("flash")]
        public void TestConvertStringToGasolineType_CalledWithInvalidArgument_ThrowAnException(string gasType)
        {
            Assert.Catch<Exception>(() => Car.ConvertStringToGasolineType(gasType));
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
            int currentNumber = _car.NumberOfViews;

            _car.IncreaseNumberOfViews();

            Assert.AreEqual(_car.NumberOfViews, currentNumber + 1);
        }

        [Test]
        public void GenerateOverview_WhenCalled_GenerateCarOverviewProperly()
        {
            var vm = _car.GenerateOverviewViewModel();

            Assert.AreEqual(_car.Id, vm.Id);
            Assert.AreEqual(_car.Maker, vm.Maker);
            Assert.AreEqual(_car.Model, vm.Model);
            Assert.AreEqual(_car.KilometersTraveled, vm.KilometersTraveled);
            Assert.AreEqual(_car.City, vm.City);

            for(int i = 0; i < vm.Pictures.Length; i++)
            {
                Assert.AreEqual(_car.Pictures[i].Picture, vm.Pictures[i]);
            }
        }

        [Test]
        public void TestGenerateCarOutPutViewModel_WhenCalled_ConstructCarOutputViewModelProperly()
        {
            var vm = _car.GenerateCarOutputViewModel();

            string gasolineType = Car.ConvertGasolineTypeToString(_car.GasolineType);
            string typeOfExchange = Car.ConvertTypeOfExchangeToString(_car.ExchangeType);

            Assert.AreEqual(vm.Id, _car.Id);
            Assert.AreEqual(vm.Plate, _car.Plate);
            Assert.AreEqual(vm.Maker, _car.Maker);
            Assert.AreEqual(vm.Model, _car.Model);
            Assert.AreEqual(vm.MakeDate, _car.MakeDate);
            Assert.AreEqual(vm.MakedDate, _car.MakedDate);
            Assert.AreEqual(vm.KilometersTraveled, _car.KilometersTraveled);
            Assert.AreEqual(vm.Price, _car.Price);
            Assert.AreEqual(vm.AcceptsChange, _car.AcceptsChange);
            Assert.AreEqual(vm.IpvaIsPaid, _car.IpvaIsPaid);
            Assert.AreEqual(vm.IsLicensed, _car.IsLicensed);
            Assert.AreEqual(vm.IsArmored, _car.IsArmored);
            Assert.AreEqual(vm.Message, _car.Message);
            Assert.AreEqual(vm.Color, _car.Color);
            Assert.AreEqual(vm.NumberOfViews, _car.NumberOfViews);
            Assert.AreEqual(vm.GasolineType, gasolineType);
            Assert.AreEqual(vm.TypeOfExchange, typeOfExchange);
        }

        [Test]
        public void GenerateCarWithInsertCarVM_ViewModelIsNull_ThrowAnException()
        {
            Assert.Catch<Exception>(() => Car.GenerateWithInsertCarViewModel(null, null));
        }

        [Test]
        public void GenerateCarWithInsertCarVM_ViewModelIsValid_ConstructACar()
        {
            InsertCarViewModel vm = new()
            {
                Plate = "JKH-9087",
                Maker = "Ford",
                Model = "Mustang",
                MakeDate = 2020,
                MakedDate = 2021,
                KilometersTraveled = 2000,
                Price = 350000,
                AcceptsChange = false,
                IpvaIsPaid = true,
                IsLicensed = true,
                IsArmored = false,
                Message = "This car has a nice sound",
                ExchangeType = "automatic",
                GasolineType = "gasoline",
                Color = "#FFFFF",
                UserEmail = "gustavo@gmail.com",
                City = "Campinas",
                Pictures = new List<string> { "dsajdksajdkslajdksa", "dsadhsajkdhsjahj" }
            };

            Car car = Car.GenerateWithInsertCarViewModel(vm, _owner);

            Assert.IsNotNull(car);
        }
    }
}
