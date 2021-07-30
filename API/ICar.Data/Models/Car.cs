using ICar.Infrastructure.Database.Models.Enums.Car;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Database.Models
{
    public class Car
    {
        public string Plate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int MakeDate { get; set; }
        public int MakedDate { get; set; }
        public double KilometersTraveled { get; set; }
        public double Price { get; set; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsArmored { get; set; }
        public string Message { get; set; }
        public TypeOfExchange TypeOfExchange { get; set; }
        public string Color { get; set; }
        public GasolineType GasolineType { get; set; }
        public int NumberOfViews { get; set; }

        public User Owner { get; set; }
        public City City { get; set; }
        public List<CarPicture> Pictures { get; set; }

        public Car()
        {

        }

        public static TypeOfExchange ConvertStringToTypeOfExchange(string typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case "automatic":
                    return TypeOfExchange.Automatic;
                case "manual":
                    return TypeOfExchange.Manual;
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static string ConvertTypeOfExchangeToString(TypeOfExchange typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case TypeOfExchange.Automatic:
                    return "automatic";
                case TypeOfExchange.Manual:
                    return "manaul";
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
