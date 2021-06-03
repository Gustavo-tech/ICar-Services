using ICar.Infrastructure.Models.Abstracts;

namespace ICar.Infrastructure.Models
{
    public class UserCar : AbstractCar
    {
        public User User { get; set; }

        public UserCar()
        { }
    }
}
