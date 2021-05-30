using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities.Logins
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserCpf { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }

        public UserLogin()
        { }

        public UserLogin(int id, string userCpf, User user, DateTime time)
        {
            Id = id;
            UserCpf = userCpf;
            User = user;
            Time = time;
        }
    }
}
