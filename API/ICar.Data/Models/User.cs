using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ICar.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }

        public List<News> News { get; set; }
        public List<Login> Logins { get; set; }
        public List<Car> Cars { get; set; }
        public List<Message> MessagesReceived { get; set; }
        public List<Message> MessagesSent { get; set; }

        public User()
        { }

        public User(string name, string phone, string email, string role)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone)
                || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
            {
                throw new InvalidOperationException("Can't create a user with null or white space value");
            }
            
            if (!ValidatePhoneFormat(phone))
                throw new FormatException($"{nameof(phone)} is not formatted");

            UserName = name;
            PhoneNumber = phone;
            Email = email;
            AccountCreationDate = DateTime.Now;
            Role = role;
        }

        public dynamic GenerateApiOutput()
        {
            return new
            {
                UserName,
                Email,
                AccountCreationDate,
                Role
            };
        }

        private static bool ValidatePhoneFormat(string phone)
        {
            return Regex.IsMatch(phone, "[(][0-9]{2}[)][ ][0-9]{5}[-][0-9]{4}");
        }
    }
}
