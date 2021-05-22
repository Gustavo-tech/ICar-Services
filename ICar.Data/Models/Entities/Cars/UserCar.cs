using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities.Cars
{
    public class UserCar : AbstractCar
    {
        public User User { get; set; }

        public UserCar(string plate, string maker, string model,
            int makeDate, int makedDate, double kilometersTraveled,
            double price, bool acceptsChange, bool ipvaIsPaid,
            bool isLicensed, bool isArmored, string message,
            TypeOfExchange typeOfExchange, Color color, GasolineType gasolineType,
            City city, int numberOfViews, User user)
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
            User = user;
        }
    }
}
