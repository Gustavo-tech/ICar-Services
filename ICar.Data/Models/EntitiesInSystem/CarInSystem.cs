using ICar.Data.Converter;
using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.EntitiesInSystem
{
    public class CarInSystem : AbstractCar
    {
        
        public TypeOfExchange TypeOfExchange { get; }
        public Color Color { get; }
        public GasolineType GasolineType { get; }
        public string City { get; set; }
        public string UserCpf { get; set; }
        public string CompanyCnpj { get; set; }
        public int NumberOfViews { get; set; }

        public CarInSystem(string plate, string maker, string model,
            int makeYear, int makedYear, double kilometers,
            string typeOfExchange, double price, Color color,
            bool acceptsChange, bool ipvaIsPaid, bool isLicensed,
            GasolineType gasolineType, bool isArmored, string message,
            string city, string userCpf, string companyCnpj)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeYear;
            MakedDate = MakedDate;
            KilometersTraveled = kilometers;
            TypeOfExchange = CarPropertyConverter.ConvertStringToTypeOfExchange(typeOfExchange);
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
