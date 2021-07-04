namespace IdentityServer.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; }
        public string Password { get; }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
