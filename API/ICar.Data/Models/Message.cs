using System;

namespace ICar.Infrastructure.Models
{
    public class Message : Entity
    {
        public User FromUser { get; private set; }
        public User ToUser { get; private set; }
        public string Text { get; private set; }
        public DateTime SendAt { get; private set; }

        private Message()
        {
        }

        public Message(User fromUser, User toUser, string text)
            : base()
        {
            if (fromUser is null || toUser is null)
            {
                throw new ArgumentNullException("Any user must not be null");
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Message text must not be null");
            }

            SendAt = DateTime.Now;
            FromUser = fromUser;
            ToUser = toUser;
            Text = text;
        }

        public dynamic ToApiOutput()
        {
            return new
            {
                Id,
                FromUser = new
                {
                    FromUser.Email,
                    FromUser.UserName
                },
                ToUser = new
                {
                    ToUser.Email,
                    ToUser.UserName
                },
                SendAt
            };
        }

        public Talk ToTalk(string sendLast)
        {
            return new Talk(sendLast, Text);
        }
    }
}
