using ICar.Data.Models.Abstract;
using System;

namespace ICar.Data.Models
{
    public sealed class User : Entity
    {
        public string Cpf { get; }

        public User(string name, string email, string password, string city,
            string cpf)
        {
            Name = name;
            Email = email;
            Password = password;
            City = city;
            Cpf = cpf;
        }

        public User(string name, string email, string password, string city,
            int numberOfCarsSelling, DateTime accountCreationDate, string role, string cpf)
        {
            Name = name;
            Email = email;
            Password = password;
            City = city;
            NumberOfCarsSelling = numberOfCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
            Cpf = cpf;
        }
    }
}
