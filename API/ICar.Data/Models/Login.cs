using System;

namespace ICar.Infrastructure.Models
{
    public class Login
    {
        public int? Id { get; private set; }
        public DateTime Time { get; private set; }
        public bool Success { get; private set; }
        public User User { get; private set; }

        private Login()
        {
            
        }

        private Login(User user, bool success)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user), "User can't be null");

            User = user;
            Success = success;
            Time = DateTime.Now;
        }

        public static Login GenerateSuccessfulLogin(User user)
        {
            return new Login(user, true);
        }

        public static Login GenerateFailedLogin(User user)
        {
            return new Login(user, false);
        }

        public dynamic GenerateLoginOutput()
        {
            return new
            {
                Id,
                Time,
                Success
            };
        }
    }
}
