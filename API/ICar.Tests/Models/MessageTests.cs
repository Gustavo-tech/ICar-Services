﻿using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    class MessageTests
    {
        [Test]
        public void TestMessageConstructor_UserIsNull_ThrowAnException()
        {
            Assert.Throws<ArgumentNullException>(() => new Message(null, null, "Some text"));
        }

        [Test]
        [TestCase("     ")]
        [TestCase("")]
        [TestCase(null)]
        public void TestMessageConstructor_MessageIsInvalid_ThrowAnException(string message)
        {
            User from = new("548.458.456-45", "Gustavo", "(19) 99822-1233", "gustavo@gmail.com", "admin");
            User to = new("312.422.892-45", "John", "(11) 99112-1133", "john@gmail.com", "admin");

            Assert.Throws<ArgumentNullException>(() => new Message(from, to, message));
        }
    }
}