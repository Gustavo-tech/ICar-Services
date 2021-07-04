using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.ViewModels.UserCar
{
    public class UserCarViewModel
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
        public string UserCpf { get; }
        public string City { get; }
        public List<string> CarImages { get; }

        public UserCarViewModel(string plate, string maker, string model, 
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
            UserCpf = userCpf;
            City = city;
            CarImages = carImages;
        }
    }
}
