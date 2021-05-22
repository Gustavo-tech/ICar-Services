using ICar.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Accounts
{
    public class User : Entity
    {

        [Key]
        public string Cpf { get; set; }
        public City City { get; set; }

        public User(string cpf, string name, string email, string password, string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = new (city);
        }

        public User(string cpf, string name, string email,
            string password, DateTime accountCreationDate, List<Car> carsSelling,
            List<Car> favoriteCars, City city, string role)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = accountCreationDate;
            CarsSelling = carsSelling;
            FavoriteCars = favoriteCars;
            City = city;
            Role = role;
        }
    }
}
