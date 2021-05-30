using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities.Cars
{
    public class UserCar : AbstractCar
    {
        public User User { get; set; }

        public UserCar()
        { }
    }
}
