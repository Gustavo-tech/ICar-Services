using ICar.Data.Converter;
using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities
{
    public class Car : AbstractCar
    {

        public TypeOfExchange TypeOfExchange { get; }
        public Color Color { get; }
        public GasolineType GasolineType { get; }
        public string City { get; set; }
        public string UserCpf { get; set; }
        public string CompanyCnpj { get; set; }
        public int NumberOfViews { get; set; }

        public Car(string plate, string maker, string model,
            int makeYear, int makedYear, double kilometers,
            string typeOfExchange, double price, string color,
            bool acceptsChange, bool ipvaIsPaid, bool isLicensed,
            string gasolineType, bool isArmored, string message,
            string city, string userCpf, string companyCnpj, int numberOfViews)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeYear;
            MakedDate = makedYear;
            KilometersTraveled = kilometers;
            TypeOfExchange = CarPropertyConverter.ConvertStringToTypeOfExchange(typeOfExchange);
            Price = price;
            Color = CarPropertyConverter.ConvertStringToColor(color);
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            GasolineType = CarPropertyConverter.ConvertStringToGasolineType(gasolineType);
            IsArmored = isArmored;
            Message = message;
            City = city;
            UserCpf = userCpf;
            CompanyCnpj = companyCnpj;
            NumberOfViews = numberOfViews;
        }
    }
}
