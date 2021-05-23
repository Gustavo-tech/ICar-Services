using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Accounts
{
    public class User : Entity
    {

        [Key]
        public string Cpf { get; set; }
        public List<UserCar> UserCars { get; set; }
        public City City { get; set; }

        public User()
        { }

        public User(string cpf, string name, string email, string password, string city)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = new(city);
        }

        public User(string cpf, string name, string email,
            string password, DateTime accountCreationDate, List<UserCar> userCars,
            City city, string role)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = accountCreationDate;
            UserCars = userCars;
            City = city;
            Role = role;
        }
    }
}
