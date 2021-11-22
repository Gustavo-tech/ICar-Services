using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    class MessageTests
    {
        private Message _message;

        [SetUp]
        public void SetUp()
        {
            User from = new("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client");
            User to = new("Scott", "(11) 99212-9082", "scot@gmail.com", "client");

            _message = new(from, to, "Nice car");
        }

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

        [Test]
        public void TestToMessageOutputViewModel_WhenCalled_ConstructMessageOutputViewModelProperly()
        {
            var vm = _message.ToMessageOutputViewModel();

            Assert.AreEqual(vm.Id, _message.Id);
            Assert.AreEqual(vm.FromUser.Email, _message.FromUser.Email);
            Assert.AreEqual(vm.FromUser.UserName, _message.FromUser.UserName);
            Assert.AreEqual(vm.ToUser.Email, _message.ToUser.Email);
            Assert.AreEqual(vm.ToUser.UserName, _message.ToUser.UserName);
            Assert.AreEqual(vm.Text, _message.Text);
            Assert.AreEqual(vm.SentAt, _message.SentAt);
        }
    }
}
