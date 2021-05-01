using ICar.Data.Models.Abstracts;

namespace ICar.Data.Models.Entities
{
    public class User : Entity
    {
        public string Cpf { get; set; }
        public string City { get; set; }

        public User(string cpf, string name, string email, string password, string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }
    }
}
