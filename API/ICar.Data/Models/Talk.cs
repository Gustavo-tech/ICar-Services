namespace ICar.Infrastructure.Models
{
    public class Talk
    {
        public string UserName { get; set; }
        public string LastMessage { get; set; }

        public Talk(string userName, string lastMessage)
        {
            UserName = userName;
            LastMessage = lastMessage;
        }
    }
}
