﻿using ICar.Infrastructure.Models.Enums.Car;
using ICar.Infrastructure.ViewModels.Input.Car;
using ICar.Infrastructure.ViewModels.Output.Car;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICar.Infrastructure.Models
{
    public class Car : Entity
    {
        public string Plate { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public int MakeDate { get; private set; }
        public int MakedDate { get; private set; }
        public int KilometersTraveled { get; private set; }
        public int Price { get; private set; }
        public bool AcceptsChange { get; private set; }
        public bool IpvaIsPaid { get; private set; }
        public bool IsLicensed { get; private set; }
        public bool IsArmored { get; private set; }
        public string Message { get; private set; }
        public ExchangeType ExchangeType { get; private set; }
        public string Color { get; private set; }
        public GasolineType GasolineType { get; private set; }
        public int NumberOfViews { get; private set; }

        public Address Address { get; private set; }
        public User Owner { get; private set; }
        public List<CarPicture> Pictures { get; private set; } = new List<CarPicture>();

        private Car() 
            : base()
        { 
        }

        public Car(string plate, string maker, string model, 
            int makeDate, int makedDate, int kilometersTraveled, 
            int price, string message, string color, 
            ExchangeType exchangeType, GasolineType gasolineType, User owner, 
            Address address, string[] pictures, bool acceptsChange = false, 
            bool ipvaIsPaid = false, bool isLicensed = false, bool isArmored = false)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeDate;
            MakedDate = makedDate;
            KilometersTraveled = kilometersTraveled;
            Price = price;
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            IsArmored = isArmored;
            Message = message;
            ExchangeType = exchangeType;
            Color = color;
            GasolineType = gasolineType;
            Owner = owner;
            Address = address;

            foreach (string pic in pictures)
            {
                if (pic != null)
                {
                    CarPicture cp = new(pic, this);
                    Pictures.Add(cp);
                }
            }
        }

        public Car IncreaseNumberOfViews()
        {
            NumberOfViews++;
            return this;
        }

        public CarOverviewViewModel GenerateOverviewViewModel()
        {
            return new CarOverviewViewModel(Id, Maker, Model, KilometersTraveled, 
                Pictures.Select(x => x.Picture).ToArray(), Address);
        }

        public CarOutputViewModel GenerateCarOutputViewModel()
        {
            return new CarOutputViewModel()
            {
                Id = Id,
                Plate = Plate,
                Maker = Maker,
                Model = Model,
                MakeDate = MakeDate,
                MakedDate = MakedDate,
                KilometersTraveled = KilometersTraveled,
                Price = Price,
                AcceptsChange = AcceptsChange,
                IpvaIsPaid = IpvaIsPaid,
                IsLicensed = IsLicensed,
                IsArmored = IsArmored,
                Message = Message,
                TypeOfExchange = ConvertTypeOfExchangeToString(ExchangeType),
                GasolineType = ConvertGasolineTypeToString(GasolineType),
                Color = Color,
                Address = Address,
                NumberOfViews = NumberOfViews,
                Pictures = Pictures.Select(x => x.Picture).ToArray()
            };
        }

        public static Car GenerateWithInsertCarViewModel(InsertCarViewModel vm, User owner)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm), "View model must not be null");

            if (owner is null)
                throw new ArgumentNullException(nameof(owner), "Owner must not be null");

            return new Car
            {
                Owner = owner,
                Plate = vm.Plate,
                Maker = vm.Maker,
                Model = vm.Model,
                Price = vm.Price,
                MakeDate = vm.MakeDate,
                MakedDate = vm.MakedDate,
                KilometersTraveled = vm.KilometersTraveled,
                AcceptsChange = vm.AcceptsChange,
                IsArmored = vm.IsArmored,
                IsLicensed = vm.IsLicensed,
                IpvaIsPaid = vm.IpvaIsPaid,
                Message = vm.Message,
                Color = vm.Color,
                ExchangeType = ConvertStringToTypeOfExchange(vm.ExchangeType),
                GasolineType = ConvertStringToGasolineType(vm.GasolineType)
            };
        }

        public static ExchangeType ConvertStringToTypeOfExchange(string typeOfExchange)
        {
            typeOfExchange = typeOfExchange.ToLower();
            switch (typeOfExchange)
            {
                case "automatic":
                    return ExchangeType.Automatic;
                case "manual":
                    return ExchangeType.Manual;
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static string ConvertTypeOfExchangeToString(ExchangeType typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case ExchangeType.Automatic:
                    return "automatic";
                case ExchangeType.Manual:
                    return "manual";
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static GasolineType ConvertStringToGasolineType(string gasolineType)
        {
            gasolineType = gasolineType.ToLower();
            switch (gasolineType)
            {
                case "gasoline":
                    return GasolineType.Gasoline;
                case "eletric":
                    return GasolineType.Eletric;
                case "flex":
                    return GasolineType.Flex;
                case "diesel":
                    return GasolineType.Diesel;
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static string ConvertGasolineTypeToString(GasolineType gasolineType)
        {
            switch (gasolineType)
            {
                case GasolineType.Diesel:
                    return "diesel";
                case GasolineType.Gasoline:
                    return "gasoline";
                case GasolineType.Eletric:
                    return "eletric";
                case GasolineType.Flex:
                    return "flex";
                default:
                    throw new Exception("Invalid argument");
            }
        }
    }
}