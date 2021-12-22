using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client");
        }

        [Test]
        [TestCase(null, null, null, null)]
        [TestCase(" ", " ", " ", " ")]
        [TestCase("", "", "", "")]
        public void TestUserConstructor_ArgumentIsInvalid_ThrowsException(string name, string phone, string email, string role)
        {
            Assert.Catch<Exception>(() => new User(name, phone, email, role));
        }

        [Test]
        [TestCase("a", "a", "a", "a")]
        [TestCase("a", "(19) 83213(2912", "a", "a")]
        public void TestUserConstructor_ArgumentIsNotWellFormatted_ThrowsException(string name, string phone,
            string email, string role)
        {
            Assert.Catch<Exception>(() => new User(name, phone, email, role));
        }

        [Test]
        [TestCase("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client")]
        [TestCase("Bryan", "(19) 32213-2912", "dss@gmail.com", "client")]
        public void TestUserConstructor_ArgumentsAreValid_ConstructsAnUser(string name, string phone, string email, string role)
        {
            User user = new(name, phone, email, role);

            Assert.IsNotNull(user);
        }

        [Test]
        public void TestToUserOutputViewModel_WhenCalled_ConstructsUserOutputViewModelProperly()
        {
            var vm = _user.ToUserOutputViewModel();

            Assert.AreEqual(vm.UserName, _user.UserName);
            Assert.AreEqual(vm.Email, _user.Email);
            Assert.AreEqual(vm.Role, _user.Role);
            Assert.AreEqual(vm.AccountCreationDate, _user.AccountCreationDate);
        }

        [Test]
        public void TestUserContainNews_UserContainNews_ReturnsTrue()
        {
            News news = new("Batman", "Batman", _user);
            _user.News.Add(news);

            Assert.IsTrue(_user.ContainNews(news.Id));
        }

        [Test]
        public void TestUserContainNews_UserDoesNotContainNews_ReturnFalse()
        {
            News news = new("Batman", "Batman", _user);

            Assert.IsTrue(_user.ContainNews(news.Id));
        }
    }
}
