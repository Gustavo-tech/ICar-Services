using ICar.Data.Converter;
using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICar.API.Generators
{
    public static class CarOutputFactory
    {
        public static dynamic GenerateUserCarOutput(Car car)
        {
            return new
            {
                car.Plate,
                car.Maker,
                car.Model,
                car.MakeDate,
                car.MakedDate,
                car.KilometersTraveled,
                car.Price,
                car.AcceptsChange,
                car.IpvaIsPaid,
                car.IsLicensed,
                car.IsArmored,
                car.Message,
                TypeOfExchange = CarPropertyConverter.ConvertTypeOfExchangeToString(car.TypeOfExchange),
                Color = CarPropertyConverter.ConvertColorToString(car.Color),
                GasolineType = CarPropertyConverter.ConvertGasolineTypeToString(car.GasolineType),
                City = car.City.Name,
                car.NumberOfViews
            };
        }

        public static dynamic[] GenerateUserCarOutput(List<Car> cars)
        {
            dynamic[] output = new dynamic[cars.Count];

            try
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    output[i] = new
                    {
                        cars[i].Plate,
                        cars[i].Maker,
                        cars[i].Model,
                        cars[i].MakeDate,
                        cars[i].MakedDate,
                        cars[i].KilometersTraveled,
                        cars[i].Price,
                        cars[i].AcceptsChange,
                        cars[i].IpvaIsPaid,
                        cars[i].IsLicensed,
                        cars[i].IsArmored,
                        cars[i].Message,
                        TypeOfExchange = CarPropertyConverter.ConvertTypeOfExchangeToString(cars[i].TypeOfExchange),
                        Color = CarPropertyConverter.ConvertColorToString(cars[i].Color),
                        GasolineType = CarPropertyConverter.ConvertGasolineTypeToString(cars[i].GasolineType),
                        City = cars[i].City.Name,
                        cars[i].NumberOfViews
                    };
                }

                return output;
            }
            catch (Exception)
            {
                return output;
            }
        }
    }
}
