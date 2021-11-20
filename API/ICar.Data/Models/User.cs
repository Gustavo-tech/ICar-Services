using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool CheckIfListAlreadyContainsTalkedTo(List<User> users, Message message)
        {
            if (users is null)
                throw new ArgumentNullException(nameof(users), "users is null");

            else if (message is null)
                throw new ArgumentNullException(nameof(message), "message is null");

            bool talkedFrom = users.FirstOrDefault(u => u.Email == message.FromUser.Email) is not null;
            bool talkedTo = users.FirstOrDefault(u => u.Email == message.ToUser.Email) is not null;

            return talkedFrom || talkedTo;
        }
        private static bool ValidatePhoneFormat(string phone)
        {
            return Regex.IsMatch(phone, "[(][0-9]{2}[)][ ][0-9]{5}[-][0-9]{4}");
        }
    }
}
