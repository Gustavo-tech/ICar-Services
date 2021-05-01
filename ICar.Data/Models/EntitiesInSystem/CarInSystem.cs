using ICar.Data.Models.Entities;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.EntitiesInSystem
{
    public class CarInSystem : Car
    {
        public UserInSystem User { get; }
        public CompanyInSystem Company { get; set; }
        public int NumberOfViews { get; set; }

        public CarInSystem(string plate, string maker, string model,
            int makeDate, int makedDate, double kilometersTraveled,
            TypeOfExchange typeOfExchange, double price, Color color,
            bool acceptsChange, bool ipvaIsPaid, bool isLicensed,
            GasolineType gasolineType, bool isArmored, string message,
            string city, string userCpf, string companyCnpj)

                : base(plate, maker, model, makeDate,
                      makedDate, kilometersTraveled, typeOfExchange,
                      price, color, acceptsChange, ipvaIsPaid,
                      isLicensed, gasolineType, isArmored,
                      message, city, userCpf, companyCnpj)
        {

        }
    }
}
