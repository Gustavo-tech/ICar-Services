using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities.Accounts
{
    public class User : Entity
    {

        [Key]
        public string Cpf { get; set; }

        [ForeignKey("UserCpfFk")]
        public List<UserCar> UserCars { get; set; }

        [ForeignKey("UserCpfFk")]
        public List<UserLogin> UserLogins { get; set; }

        [ForeignKey("UserCpfFk")]
        public List<UserNews> UserNews { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public int CityId { get; set; }

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
