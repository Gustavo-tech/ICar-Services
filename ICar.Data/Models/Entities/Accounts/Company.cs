using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using System;
using System.Collections.Generic;

namespace ICar.Data.Models.Entities.Accounts
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
