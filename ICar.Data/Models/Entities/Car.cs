using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities
{
    public class Car : AbstractCar
    {
        public string TypeOfExchange { get; }
        public string Color { get; }
        public string GasolineType { get; }
        public string City { get; set; }
        public string UserCpf { get; }
        public string CompanyCnpj { get; set; }

        public Car(string plate, string maker, string model, int makeYear,
            int makedYear, double kilometers, string typeOfExchange,
            double price, string color, bool acceptsChange,
            bool ipvaIsPaid, bool isLicensed,
            string gasolineType, bool isArmored,
            string message, string city, string userCpf, string companyCnpj)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeYear;
            MakedDate = makedYear;
            KilometersTraveled = kilometers;
            TypeOfExchange = typeOfExchange;
            Price = price;
            Color = color;
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            GasolineType = gasolineType;
            IsArmored = isArmored;
            Message = message;
            City = city;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
        }
    }
}
