using ICar.Data.Models.Abstract;
using System;
using System.Collections.Generic;

namespace ICar.Data.Models
{
    public sealed class Company : Entity
    {
        public int Id { get; }
        public string Cnpj { get; }
        public List<string> Cities { get; set; }

        public Company(int id, string cnpj, string name, string email, string password, List<string> cities)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
            Cnpj = cnpj;
        }

        public Company(int id, string cnpj, string name, string email, string password, List<string> cities,
            int numberOfCarsSelling, DateTime accountCreationDate, string role)
        {
            Id = id;
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
