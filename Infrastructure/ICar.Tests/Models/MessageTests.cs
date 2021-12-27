using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Tests.Models
{
    class MessageTests
    {
        private Message _message;

        [SetUp]
        public void SetUp()
        {
            _message = new("ggg", "hhh", "Hello");
        }

        [Test]
        public void TestGetLastMessageWithUsers_WhenCalled_ReturnsLastMessagesWithUsers()
        {
            string secondMessageText = "How are you?";
            string thirdMessageText = "I liked your car!";
            List<Message> messages = new()
            {
                new Message("hhh", "ggg", secondMessageText),
                new Message("lll", "ggg", thirdMessageText)
            };

            List<LastMessageWithUser> lastMessageWithUsers = Message.GetLastMessageWithUsers("ggg", messages);

            Assert.IsTrue(lastMessageWithUsers[0].LastMessage == secondMessageText);
            Assert.IsTrue(lastMessageWithUsers[1].LastMessage == thirdMessageText);
        }
    }
}
