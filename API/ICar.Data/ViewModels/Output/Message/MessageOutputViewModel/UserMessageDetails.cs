namespace ICar.Infrastructure.ViewModels.Output.Message
{
    public class UserMessageDetails
    {
        public string Email { get; private set; }
        public string UserName { get; private set; }

        public UserMessageDetails(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }
    }
}
