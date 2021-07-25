using System.Collections.Generic;

namespace ICar.API.ViewModels.Car
{
    public class CarViewModel
    {
        public string Plate { get; }
        public string Maker { get; }
        public string Model { get; }
        public int MakeDate { get; }
        public int MakedDate { get; }
        public double KilometersTraveled { get; }
        public double Price { get; }
        public bool AcceptsChange { get; }
        public bool IpvaIsPaid { get; }
        public bool IsLicensed { get; }
        public bool IsArmored { get; }
        public string Message { get; }
        public string TypeOfExchange { get; }
        public string Color { get; }
        public string GasolineType { get; }
        public string UserEmail { get; }
        public string City { get; }
        public List<string> CarImages { get; }

        public CarViewModel(string plate, string maker, string model,
            int makeDate, int makedDate, double kilometersTraveled, double price,
            bool acceptsChange, bool ipvaIsPaid, bool isLicensed,
            bool isArmored, string message, string typeOfExchange,
            string color, string gasolineType, string userCpf,
            string city, List<string> carImages)
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
            UserEmail = userCpf;
            City = city;
            CarImages = carImages;
        }
    }
}
