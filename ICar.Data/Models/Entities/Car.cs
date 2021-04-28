﻿using ICar.Data.Models.Enums;

namespace ICar.Data.Models {
    public class Car {
        public string Plate { get; }
        public string Maker { get; }
        public string Model { get; }
        public int MakeDate { get; }
        public int MakedDate { get; }
        public double KilometersTraveled { get; }
        public TypeOfExchange TypeOfExchange { get; }
        public double Price { get; set; }
        public string Color { get; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public GasolineType GasolineType { get; }
        public bool IsArmored { get; }
        public string Message { get; }
        public int CityId { get; set; }
        public User User { get; }
        public Company Company { get; set; }
        public int NumberOfViews { get; set; }

        public Car(string plate, string maker, string model, 
            int makeDate, int makedDate, double kilometersTraveled, 
            TypeOfExchange typeOfExchange, double price, string color,
            bool acceptsChange, bool ipvaIsPaid, bool isLicensed, 
            GasolineType gasolineType, bool isArmored, string message, 
            int cityId, User user, Company company, int numberOfViews
            ) {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeDate;
            MakedDate = makedDate;
            KilometersTraveled = kilometersTraveled;
            TypeOfExchange = typeOfExchange;
            Price = price;
            Color = color;
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            GasolineType = gasolineType;
            IsArmored = isArmored;
            Message = message;
            CityId = cityId;
            User = user;
            Company = company;
            NumberOfViews = numberOfViews;
        }
    }
}
