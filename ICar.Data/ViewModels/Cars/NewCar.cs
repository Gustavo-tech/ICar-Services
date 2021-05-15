using ICar.Data.Models.Abstracts;

namespace ICar.Data.ViewModels.Cars
{
    public class NewCar : AbstractCar
    {
        public string TypeOfExchange { get; }
        public string Color { get; }
        public string GasolineType { get; }
        public string City { get; set; }
        public string UserCpf { get; }
        public string CompanyCnpj { get; set; }

        public NewCar(string plate, string maker, string model, int makeDate,
            int makedDate, double kilometersTraveled, string typeOfExchange,
            double price, string color, bool acceptsChange,
            bool ipvaIsPaid, bool isLicensed,
            string gasolineType, bool isArmored,
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
