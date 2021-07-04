﻿using ICar.Infrastructure.Database.Converter;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Models.Enums.Car;

namespace ICar.API.Builders
{
    public class CarBuilder
    {
        private Car _car;

        public CarBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _car = new();
        }

        public CarBuilder WithPlate(string plate)
        {
            _car.Plate = plate;
            return this;
        }

        public CarBuilder WithMaker(string maker)
        {
            _car.Maker = maker;
            return this;
        }

        public CarBuilder WithModel(string model)
        {
            _car.Model = model;
            return this;
        }

        public CarBuilder WithMakeDate(int makeDate)
        {
            _car.MakeDate = makeDate;
            return this;
        }

        public CarBuilder WithMakedDate(int makedDate)
        {
            _car.MakedDate = makedDate;
            return this;
        }

        public CarBuilder WithKilometersTraveled(double kilometersTraveled)
        {
            _car.KilometersTraveled = kilometersTraveled;
            return this;
        }

        public CarBuilder WithPrice(double price)
        {
            _car.Price = price;
            return this;
        }

        public CarBuilder WithAcceptsChange(bool acceptsChange)
        {
            _car.AcceptsChange = acceptsChange;
            return this;
        }

        public CarBuilder WithIpvaIsPaid(bool ipvaIsPaid)
        {
            _car.IpvaIsPaid = ipvaIsPaid;
            return this;
        }

        public CarBuilder WithIsLicensed(bool isLicensed)
        {
            _car.IsLicensed = isLicensed;
            return this;
        }

        public CarBuilder WithIsArmored(bool irArmored)
        {
            _car.IsArmored = irArmored;
            return this;
        }

        public CarBuilder WithMessage(string message)
        {
            _car.Message = message;
            return this;
        }

        public CarBuilder WithTypeOfExchange(string typeOfExchange)
        {
            TypeOfExchange typeOfExchangeForCar = CarPropertyConverter.ConvertStringToTypeOfExchange(typeOfExchange);
            _car.TypeOfExchange = typeOfExchangeForCar;
            return this;
        }

        public CarBuilder WithGasolineType(string gasolineType)
        {
            GasolineType gasolineTypeForCar = CarPropertyConverter.ConvertStringToGasolineType(gasolineType);
            _car.GasolineType = gasolineTypeForCar;
            return this;
        }

        public CarBuilder WithColor(string color)
        {
            Color colorForCar = CarPropertyConverter.ConvertStringToColor(color);
            _car.Color = colorForCar;
            return this;
        }

        public CarBuilder WithCompanyCnpj(string cnpj)
        {
            _car.CompanyCnpj = cnpj;
            return this;
        }

        public CarBuilder WithUserCpf(string userCpf)
        {
            _car.UserCpf = userCpf;
            return this;
        }

        public CarBuilder WithCity(City city)
        {
            _car.CityId = city.Id.Value;
            _car.City = city;
            return this;
        }

        public Car GetResult()
        {
            Car result = _car;
            Reset();
            return result;
        }
    }
}
