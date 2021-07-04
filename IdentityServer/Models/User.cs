using Microsoft.AspNetCore.Identity;
using System;

namespace ICar.IdentityServer.Models
{
    public class User : IdentityUser
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }

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
    }
}
