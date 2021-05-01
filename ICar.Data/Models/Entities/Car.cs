using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities
{
    public class Car
    {
        public string Plate { get; }
        public string Maker { get; }
        public string Model { get; }
        public int MakeDate { get; }
        public int MakedDate { get; }
        public double KilometersTraveled { get; }
        public TypeOfExchange TypeOfExchange { get; }
        public double Price { get; set; }
        public Color Color { get; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public GasolineType GasolineType { get; }
        public bool IsArmored { get; }
        public string Message { get; }
        public string City { get; set; }
        public string UserCpf { get; }
        public string CompanyCnpj { get; set; }

        public Car(string plate, string maker, string model, int makeDate,
            int makedDate, double kilometersTraveled, TypeOfExchange typeOfExchange,
            double price, Color color, bool acceptsChange,
            bool ipvaIsPaid, bool isLicensed,
            GasolineType gasolineType, bool isArmored,
            string message, string city, string userCpf, string companyCnpj)
        {
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
            City = city;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
        }
    }
}
