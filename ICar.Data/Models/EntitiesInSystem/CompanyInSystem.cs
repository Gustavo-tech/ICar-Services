using ICar.Data.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace ICar.Data.Models.EntitiesInSystem
{
    public sealed class CompanyInSystem : Entity
    {
        public string Cnpj { get; }
        public List<string> Cities { get; set; }

        public CompanyInSystem(string cnpj, string name, string email, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }

        public CompanyInSystem(string cnpj, string name, string email, string password,
            int numberOfCarsSelling, DateTime accountCreationDate, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            NumberOfCarsSelling = numberOfCarsSelling;
            AccountCreationDate = accountCreationDate;
            Role = role;
        }

        public CompanyInSystem(string cnpj, string name, string email, string password, List<string> cities,
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
