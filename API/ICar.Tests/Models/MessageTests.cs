using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    [TestFixture]
    class MessageTests
    {
        [Test, Combinatorial]
        public void TestMessageConstructor_UserIsNull_ThrowAnException(
            [Values(null)] User from,
            [Values(null)] User to,
            [Values(null, "", " ")] string text)
        {
            Assert.Catch<Exception>(() => new Message(from, to, text));
        }

        [Test]
        [TestCase("     ")]
        [TestCase("")]
        [TestCase(null)]
        public void TestMessageConstructor_MessageIsInvalid_ThrowAnException(string message)
        {
            User from = new("Gustavo", "(19) 99822-1233", "gustavo@gmail.com", "admin");
            User to = new("John", "(11) 99112-1133", "john@gmail.com", "admin");

            Assert.Catch<Exception>(() => new Message(from, to, message));
        }
    }
}
