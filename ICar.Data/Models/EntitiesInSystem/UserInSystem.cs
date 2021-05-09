using ICar.Data.Models.Abstracts;
using System;

namespace ICar.Data.Models.EntitiesInSystem
{
    public sealed class UserInSystem : Entity
    {
        public string Cpf { get; }
        public string City { get; set; }

        public UserInSystem(string cpf, string name, string email, string password,
            string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }

        public UserInSystem(string cpf, string name, string email, string password,
            int numberOfCarsSelling, DateTime accountCreationDate, string role, string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
            NumberOfCarsSelling = numberOfCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
        }
    }
}
