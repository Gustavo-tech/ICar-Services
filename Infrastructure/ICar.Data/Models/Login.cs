using ICar.Infrastructure.ViewModels.Output.Login;
using System;

namespace ICar.Infrastructure.Models
{
    public class Login : Entity
    {
        private User _user;

        public User User
        {
            get { return _user; }
            private set
            {
                if (value is null)
                    throw new Exception("User can't be null");

                _user = value;
            }
        }

        public DateTime Time { get; private set; }
        public bool Success { get; private set; }

        private Login()
        {

        }

        private Login(User user, bool success) : base()
        {
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

        public LoginOutputViewModel GenerateLoginOutputViewModel()
        {
            return new LoginOutputViewModel(Id, Time, Success);
        }
    }
}
