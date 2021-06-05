using ICar.Infrastructure.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Models
{
    public class Company : Entity
    {
        public string Cnpj { get; set; }
        public List<City> Cities { get; set; }

        public Company()
        { }

        public Company(string cnpj, string name, string email, string password, string role)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            AccountCreationDate = DateTime.Now;
        }
    }
}
