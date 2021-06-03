using ICar.Infrastructure.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Models
{
    public class User : Entity
    {
        public string Cpf { get; set; }
        public List<UserCar> UserCars { get; set; }
        public List<UserLogin> UserLogins { get; set; }
        public List<UserNews> UserNews { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public User()
        { }

        public User(string cpf, string name, string email,
            string password, string role)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = DateTime.Now;
            Role = role;
        }

        public User(string cpf, string name, string email,
            string password, DateTime accountCreationDate, string role,
            City city, List<UserCar> userCars, List<UserLogin> userLogins,
            List<UserNews> userNews)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            AccountCreationDate = accountCreationDate;
            Role = role;
            City = city;
            UserCars = userCars;
            UserLogins = userLogins;
            UserNews = userNews;
        }
    }
}
