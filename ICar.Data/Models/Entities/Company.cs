using ICar.Data.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace ICar.Data.Models.Entities
{
    public sealed class Company : Entity
    {
        public string Cnpj { get; }
        public List<City> Cities { get; set; }

        public Company(string cnpj, string name, string email, string password, List<City> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }

        public Company(string cnpj, string name, string email, string password,
            int numberOFCarsSelling, DateTime accountCreationDate, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            NumberOfCarsSelling = numberOFCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
        }

        public Company(string cnpj, string name, string email, string password, List<City> cities,
            int numberOfCarsSelling, DateTime accountCreationDate, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
            NumberOfCarsSelling = numberOfCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
        }
    }
}
