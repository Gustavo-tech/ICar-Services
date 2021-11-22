using ICar.Infrastructure.ViewModels.Output.Message;
using System;

namespace ICar.Infrastructure.Models
{
    public class Message : Entity
    {
        private User _fromUser;
        private User _toUser;
        private string _text;

        public User FromUser
        {
            get { return _fromUser; }
            private set
            {
                if (value is null)
                    throw new Exception("From user must not be null");

                _fromUser = value;
            }
        }

        public User ToUser
        {
            get { return _toUser; }
            private set
            {
                if (value is null)
                    throw new Exception("To user must not be null");

                _toUser = value;
            }
        }

        public string Text
        {
            get { return _text; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Text must not be null or empty");

                _text = value;
            }
        }

        public DateTime SentAt { get; private set; }

        private Message()
        {
        }

        public Message(User fromUser, User toUser, string text)
            : base()
        {
            FromUser = fromUser;
            ToUser = toUser;
            Text = text;
            SentAt = DateTime.Now;
        }

        public MessageOutputViewModel ToMessageOutputViewModel()
        {
            UserMessageDetails from = new(FromUser.Email, FromUser.UserName);
            UserMessageDetails to = new(ToUser.Email, ToUser.UserName);

            return new MessageOutputViewModel(Id, Text, SentAt, from, to);
        }

        public Talk ToTalk(string sendLast)
        {
            return new Talk(sendLast, Text);
        }
    }
}
