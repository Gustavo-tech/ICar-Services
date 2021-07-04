using ICar.Infrastructure.Database.Models.Abstracts;
using System;

namespace ICar.Infrastructure.Database.Models
{
    public class User : Entity
    {
        public string Cpf { get; set; }

        public User()
        { }

        public User(string cpf, string name, string email,
            string password, string role)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = DateTime.Now;
            Role = role;
        }
    }
}
