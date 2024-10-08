﻿using ICar.Infrastructure.Models;
using ICar.Infrastructure.Models.Enums.Car;
using ICar.Infrastructure.ViewModels.Input;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    class CarTests
    {
        private Car _car;
        private string _ownerId;

        [SetUp]
        public void SetUp()
        {
            _ownerId = "1b341fcc-5e21-45bd-ba52-872426b36da3";

            _car = new("JKH-9087", "Ford", "Mustang", 2020, 2021, 2000, 350000,
                "This car has a nice sound", "#FFFFF", ExchangeType.Manual, GasolineType.Gasoline,
                _ownerId, new string[] { "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBUVF" }, null);
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

            for (int i = 0; i < vm.Pictures.Length; i++)
            {
                Assert.AreEqual(_car.Pictures[i].PictureUrl, vm.Pictures[i]);
            }
        }

        [Test]
        public void GenerateCarWithInsertCarVM_ViewModelIsNull_ThrowAnException()
        {
            Assert.CatchAsync<Exception>(async () => await Car.GenerateWithInsertCarViewModel(null, null));
        }

        [Test]
        public async Task GenerateCarWithInsertCarVM_ViewModelIsValid_ConstructACar()
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
                Address = new AddressInfo("13044650", "Campinas", "Jardim Antonio Von Zuben", "Rua Antônio Bertoni Garcia"),
                Pictures = new string[] { "dsajdksajdkslajdksa", "dsadhsajkdhsjahj" }
            };

            Car car = await Car.GenerateWithInsertCarViewModel(vm, _ownerId);

            Assert.IsNotNull(car);
        }

        [Test]
        [Repeat(10)]
        public void TestGeneratePictureStoragePath_WhenCalled_ReturnsTheStoragePath()
        {
            var result = _car.GeneratePictureStoragePath();

            Assert.AreEqual($"{_ownerId}/cars/{_car.Id}", result);
        }

        [Test]
        public async Task TestUpdateAddress_WhenCalled_UpdatesTheAddress()
        {
            string district = "Cidade Dutra";
            string street = "Avenida Senador Teotônio Vilela";
            string zipCode = "04801010";
            string location = "São Paulo";

            await _car.UpdateAddress(zipCode, location, district, street);

            Assert.AreEqual(zipCode, _car.Address.ZipCode);
            Assert.AreEqual(street, _car.Address.Street);
            Assert.AreEqual(location, _car.Address.Location);
            Assert.AreEqual(district, _car.Address.District);
        }

        [Test]
        public void TestUpdateBooleanProperties_WhenCalled_UpdatesBooleanProperties()
        {
            bool acceptsChange = true;
            bool ipvaIsPaid = false;
            bool isLicensed = true;
            bool isArmored = false;

            _car.UpdateBooleanProperties(acceptsChange, ipvaIsPaid, isLicensed, isArmored);

            Assert.AreEqual(acceptsChange, _car.AcceptsChange);
            Assert.AreEqual(ipvaIsPaid, _car.IpvaIsPaid);
            Assert.AreEqual(isLicensed, _car.IsLicensed);
            Assert.AreEqual(isArmored, _car.IsArmored);
        }

        [Test]
        public void TestUpdateMessage_WhenCalled_UpdatesTheMessage()
        {
            string message = "This car is a beast";
            _car.UpdateMessage(message);

            Assert.AreEqual(message, _car.Message);
        }

        [Test]
        public void TestUpdatePrice_WhenCalled_UpdatesThePrice()
        {
            int price = 18000;
            _car.UpdatePrice(price);

            Assert.AreEqual(price, _car.Price);
        }

        [Test]
        public void TestUpdateKilometersTraveled_WhenCalled_UpdatesTheKilometers()
        {
            int kilometers = 18000;
            _car.UpdateKilometersTraveled(kilometers);

            Assert.AreEqual(kilometers, _car.KilometersTraveled);
        }
    }
}
