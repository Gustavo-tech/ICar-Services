namespace ICar.Infrastructure.Models
{
    public class Talk
    {
        public string UserName { get; private set; }
        public string LastMessage { get; private set; }

        public Talk(string userName, string lastMessage)
        {
            UserName = userName;
            LastMessage = lastMessage;
        }
    }
}
