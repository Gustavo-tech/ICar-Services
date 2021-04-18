using ICar.Data.Models.Abstract;
using System;
using System.Collections.Generic;

namespace ICar.Data.Models {
    public sealed class Company : Entity {
        public string Cnpj { get; }
        public List<string> Cities { get; set; }

        public Company(string cnpj, string name, string email, string password, List<string> cities) {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }

        public Company(string cnpj, string name, string email, string password,
            int numberOfCarsSelling, DateTime accountCreationDate, string role) {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            NumberOfCarsSelling = numberOfCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
        }

        public Company(string cnpj, string name, string email, string password, List<string> cities,
            int numberOfCarsSelling, DateTime accountCreationDate, string role) {
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
