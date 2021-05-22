using ICar.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Accounts
{
    public class Company : Entity
    {
        [Key]
        public string Cnpj { get; }

        public List<City> Cities { get; set; }

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
