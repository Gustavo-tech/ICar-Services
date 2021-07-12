namespace IdentityServer.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RedirectUri { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
    }
}
