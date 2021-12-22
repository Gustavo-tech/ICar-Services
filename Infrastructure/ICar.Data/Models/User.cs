using ICar.Infrastructure.ViewModels.Output.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ICar.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public DateTime AccountCreationDate { get; private set; }
        public string Role { get; private set; }

        public List<News> News { get; private set; }
        public List<Login> Logins { get; private set; }
        public List<Car> Cars { get; private set; }

        private User()
        {
        }

        public User(string name, string phone, string email, string role)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Username is empty");

            if (!ValidatePhoneFormat(phone))
                throw new ArgumentException("Invalid phone format", nameof(phone));

            if (!ValidateEmail(email))
                throw new ArgumentException("Invalid email address", nameof(phone));

            UserName = name;
            PhoneNumber = phone;
            Email = email;
            AccountCreationDate = DateTime.Now;
            Role = role;
        }

        public UserOutputViewModel ToUserOutputViewModel()
        {
            return new UserOutputViewModel(UserName, Email, Role, AccountCreationDate);
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

        public bool ContainNews(string newsId)
        {
            if (string.IsNullOrWhiteSpace(newsId))
                return false;

            News news = News.FirstOrDefault(x => x.Id == newsId);

            return news != null;
        }

        private static bool ValidatePhoneFormat(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            return Regex.IsMatch(phone, "[(][0-9]{2}[)][ ][0-9]{5}[-][0-9]{4}");
        }

        private static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress mailAddress = new(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
