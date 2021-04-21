﻿using ICar.Data.Models.Abstract;
using System;

namespace ICar.Data.Models {
    public sealed class User : Entity {
        public string Cpf { get; }
        public string City { get; set; }

        public User(string cpf, string name, string email, string password,
            string city) {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
        }

        public User(string cpf, string name, string email, string password,
            int number_of_cars_selling, DateTime account_creation_date, string role, string city) {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
            City = city;
            NumberOfCarsSelling = number_of_cars_selling;
            AccountCreationDate = account_creation_date;
            Role = role;
        }
    }
}