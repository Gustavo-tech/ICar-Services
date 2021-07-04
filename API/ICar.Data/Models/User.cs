using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Database.Models
{
    public class User : IdentityUser
    {
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
        public List<News> News { get; set; }
        public List<Login> Logins { get; set; }
        public List<Car> Cars { get; set; }
        public string Cpf { get; set; }

        public User()
        { }

        public User(string cpf, string name, string email, string role)
        {
            Cpf = cpf;
            UserName = name;
            Email = email;
            AccountCreationDate = DateTime.Now;
            Role = role;
        }
    }
}
