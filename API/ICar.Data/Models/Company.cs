using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Database.Models
{
    public class Company : IdentityUser
    {
        public string Cnpj { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
        public List<News> News { get; set; }
        public List<Login> Logins { get; set; }
        public List<Car> Cars { get; set; }

        public Company()
        { }

        public Company(string cnpj, string name, string email, string role)
        {
            Cnpj = cnpj;
            UserName = name;
            Email = email;
            Role = role;
            AccountCreationDate = DateTime.Now;
        }
    }
}
