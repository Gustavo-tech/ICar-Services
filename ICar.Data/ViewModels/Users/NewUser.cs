using ICar.Data.Models.Abstracts;

namespace ICar.Data.ViewModels.Users
{
    public class NewUser : Entity
    {
        public string Cpf { get; set; }
        public string City { get; set; }

        public NewUser(string cpf, string name, string email, string password, string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }
    }
}
