using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using System.Collections.Generic;

namespace ICar.Data.Models.Entities.Accounts
{
    public class User : Entity
    {
        public string Cpf { get; set; }
        public List<UserCar> UserCars { get; set; }
        public List<UserLogin> UserLogins { get; set; }
        public List<UserNews> UserNews { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public User()
        { }
    }
}
