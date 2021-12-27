using ICar.Infrastructure.ViewModels.Output.Message;
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

        public DateTime SentAt { get; private set; }

        private Message()
        {
        }

        public Message(string fromUser, string toUser, string text)
            : base()
        {
            FromUser = fromUser;
            ToUser = toUser;
            Text = text;
            SentAt = DateTime.Now;
        }

        public static List<LastMessageWithUser> GetLastMessageWithUsers(string userId, List<Message> messages)
        {
            List<LastMessageWithUser> lastMessageWithUsers = new();

            if (messages is null || messages.Count == 0)
                return lastMessageWithUsers;

            messages = messages.OrderBy(x => x.SentAt).ToList();

            foreach(Message message in messages)
            {
                if (message.FromUser == userId && !LastMessageWithUsersContainsUser(message.ToUser, lastMessageWithUsers))
                {
                    LastMessageWithUser lastMessageWithUser = message.ToLastMessageWithUser(message.ToUser);
                    lastMessageWithUsers.Add(lastMessageWithUser);
                }

                else if (message.ToUser == userId && !LastMessageWithUsersContainsUser(message.FromUser, lastMessageWithUsers))
                {
                    LastMessageWithUser lastMessageWithUser = message.ToLastMessageWithUser(message.FromUser);
                    lastMessageWithUsers.Add(lastMessageWithUser);
                }
            }

            return lastMessageWithUsers;
        }

        public LastMessageWithUser ToLastMessageWithUser(string userId)
        {
            return new LastMessageWithUser(userId, Text);
        }

        private static bool LastMessageWithUsersContainsUser(string userId, List<LastMessageWithUser> list)
        {
            if (userId is null || list is null)
                throw new Exception("Can't verify if user id is in the list");

            else if (list.Count == 0)
                return false;

            foreach (LastMessageWithUser lastMessageWithUser in list)
            {
                if (lastMessageWithUser.UserId == userId)
                    return true;
            }

            return false;
        }
    }
}
