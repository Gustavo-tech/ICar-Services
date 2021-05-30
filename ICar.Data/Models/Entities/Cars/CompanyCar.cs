using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Enums.Car;
using System.Collections.Generic;

namespace ICar.Data.Models.Entities.Cars
{
    public class CompanyCar
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
        public Color Color { get; set; }
        public GasolineType GasolineType { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<CarImage> CarImages { get; set; }
        public int NumberOfViews { get; set; }
        public string CompanyCnpj { get; set; }
        public Company Company { get; set; }

        public CompanyCar()
        { }

        public CompanyCar(string plate, string maker, string model,
            int makeDate, int makedDate, double kilometersTraveled,
            double price, bool acceptsChange, bool ipvaIsPaid,
            bool isLicensed, bool isArmored, string message,
            TypeOfExchange typeOfExchange, Color color, GasolineType gasolineType,
            City city, int numberOfViews, Company company)
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
            TypeOfExchange = typeOfExchange;
            Color = color;
            GasolineType = gasolineType;
            City = city;
            NumberOfViews = numberOfViews;
            Company = company;
        }
    }
}
