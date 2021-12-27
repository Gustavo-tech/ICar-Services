namespace ICar.Infrastructure.Models
{
    public class LastMessageWithUser
    {
        public string UserId { get; private set; }
        public string LastMessage { get; private set; }

        public LastMessageWithUser(string userId, string lastMessage)
        {
            UserId = userId;
            LastMessage = lastMessage;
        }
    }
}
