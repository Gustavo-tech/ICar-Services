using System;

namespace ICar.Infrastructure.ViewModels.Output.Message
{
    public class MessageOutputViewModel
    {
        public string Id { get; private set; }
        public string Text { get; private set; }
        public DateTime SentAt { get; private set; }
        public UserMessageDetails FromUser { get; private set; }
        public UserMessageDetails ToUser { get; private set; }

        public MessageOutputViewModel(string id, string text, DateTime sentAt,
            UserMessageDetails fromUser, UserMessageDetails toUser)
        {
            Id = id;
            Text = text;
            SentAt = sentAt;
            FromUser = fromUser;
            ToUser = toUser;
        }
    }
}
