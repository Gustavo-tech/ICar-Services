using ICar.Infrastructure.Models.Abstracts;

namespace ICar.Infrastructure.Models
{
    public class CompanyCar : AbstractCar
    {
        public Company Company { get; set; }

        public CompanyCar()
        { }
    }
}
