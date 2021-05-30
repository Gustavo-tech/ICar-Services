using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Enums.Car;

namespace ICar.Data.Models.Entities.Cars
{
    public class CompanyCar : AbstractCar
    {
        public Company Company { get; set; }

        public CompanyCar()
        { }
    }
}
