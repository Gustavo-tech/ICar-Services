using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities.Accounts
{
    public class Company
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
        public string Cnpj { get; set; }
        public List<CompanyCar> CompanyCars { get; set; }
        public List<City> Cities { get; set; }
        public List<CompanyLogin> CompanyLogins { get; set; }
        public List<CompanyNews> CompanyNews { get; set; }

        public Company()
        { }

        public Company(string cnpj, string name, string email,
            string password, DateTime accountCreationDate, List<CompanyCar> companyCars,
            List<City> cities, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = accountCreationDate;
            CompanyCars = companyCars;
            Cities = cities;
            Role = role;
        }
    }
}
