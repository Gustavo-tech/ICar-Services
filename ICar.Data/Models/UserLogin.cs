using System;

namespace ICar.Infrastructure.Models
{
    public class UserLogin
    {
        public int? Id { get; set; }
        public string UserCpf { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }

        public UserLogin()
        { }

        public UserLogin(User user)
        {
            User = user;
            UserCpf = user.Cpf;
            Time = DateTime.Now;
        }
    }
}
