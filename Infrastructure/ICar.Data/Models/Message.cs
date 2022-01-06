using System;
using System.Collections.Generic;
using System.Linq;

namespace ICar.Infrastructure.Models
{
    public class Message : Entity
    {
        private string _fromUser;
        private string _toUser;
        private string _text;
        private string _subjectId;

        public string FromUser
        {
            get { return _fromUser; }
            private set
            {
                if (value is null)
                    throw new Exception("From user must not be null");

                _fromUser = value;
            }
        }

        public string ToUser
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

        public string SubjectId
        {
            get { return _subjectId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 32)
                    throw new Exception("Invalid subject id");

                _subjectId = value;
            }
        }

        public DateTime SentAt { get; private set; }

        private Message()
        {
        }

        public Message(string fromUser, string toUser, string subjectId, string text)
            : base()
        {
            FromUser = fromUser;
            ToUser = toUser;
            SubjectId = subjectId;
            Text = text;
            SentAt = DateTime.Now;
        }
    }
}
