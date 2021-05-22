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

        public Company(string cnpj, string name, string email, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;

            List<City> cities1 = new();
            foreach (string item in cities)
            {
                cities1.Add(new City(item));
            }
        }

        public Company(string cnpj, string name, string email,
            string password, DateTime accountCreationDate, List<Car> carsSelling,
            List<Car> favoriteCars, List<City> cities, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = accountCreationDate;
            CarsSelling = carsSelling;
            FavoriteCars = favoriteCars;
            Cities = cities;
            Role = role;
        }
    }
}
