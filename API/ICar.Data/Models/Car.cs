using ICar.Infrastructure.Models.Enums.Car;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICar.Infrastructure.Models
{
    public class Car
    {
        public int? Id { get; private set; }
        public string Plate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int MakeDate { get; set; }
        public int MakedDate { get; set; }
        public double KilometersTraveled { get; set; }
        public int Price { get; set; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsArmored { get; set; }
        public string Message { get; set; }
        public ExchangeType ExchangeType { get; set; }
        public string Color { get; set; }
        public GasolineType GasolineType { get; set; }
        public int NumberOfViews { get; private set; }

        public User Owner { get; set; }
        public City City { get; set; }
        public List<CarPicture> Pictures { get; set; }

        public Car()
        { 
        }

        public Car IncreaseNumberOfViews()
        {
            NumberOfViews++;
            return this;
        }

        public dynamic GenerateOverview()
        {
            return new
            {
                Id,
                Maker,
                Model,
                KilometersTraveled,
                Price,
                MakeDate,
                MakedDate,
                Pictures = Pictures.Select(x => x.Picture),
                City = City.Name
            };
        }

        public dynamic GenerateApiOutput()
        {
            return new
            {
                Id,
                Plate,
                Maker,
                Model,
                MakeDate,
                MakedDate,
                KilometersTraveled,
                Price,
                AcceptsChange,
                IpvaIsPaid,
                IsLicensed,
                IsArmored,
                Message,
                TypeOfExchange = ConvertTypeOfExchangeToString(ExchangeType),
                Color,
                GasolineType = ConvertGasolineTypeToString(GasolineType),
                City = City.Name,
                NumberOfViews,
                Pictures = Pictures.Select(x => x.Picture)
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
