using System;

namespace ICar.Infrastructure.Models
{
    public class Message
    {
        public int Id { get; }
        public User FromUser { get; }
        public User ToUser { get; }
        public string Text { get; }
        public DateTime SendAt { get; }

        public Message()
        {
        }

        public Message(User fromUser, User toUser, string text)
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
