using ICar.Data.Models.Abstract;
using System;

namespace ICar.Data.Models
{
    public sealed class Company : Entity
    {
        public int Id { get; }
        public string Cnpj { get; }

        public Company(int id, string cnpj, string name, string email, string password, string city)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            City = city;
            Cnpj = cnpj;
        }

        public Company(int id, string cnpj, string name, string email, string password, string city,
            int numberOfCarsSelling, DateTime accountCreationDate, string role)
        {
            Id = id;
            Cnpj = cnpj;
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
