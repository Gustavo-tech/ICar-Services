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

        public DateTime SendAt { get; private set; }

        private Message()
        {
        }

        public Message(User fromUser, User toUser, string text)
            : base()
        {
            FromUser = fromUser;
            ToUser = toUser;
            Text = text;
            SendAt = DateTime.Now;
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
