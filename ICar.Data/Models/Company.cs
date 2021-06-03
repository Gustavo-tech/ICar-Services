﻿using ICar.Infrastructure.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Models
{
    public class Company : Entity
    {
        public string Cnpj { get; set; }
        public List<CompanyCar> CompanyCars { get; set; }
        public List<City> Cities { get; set; }
        public List<CompanyLogin> CompanyLogins { get; set; }
        public List<CompanyNews> CompanyNews { get; set; }

        public Company()
        { }

        public Company(string cnpj, string name, string email, string password, List<City> cities, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
            Role = role;
            AccountCreationDate = DateTime.Now;
        }
    }
}