using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    class NewsTests
    {
        private News _news;

        [SetUp]
        public void SetUp()
        {
            string title = "Mercedes";
            string text = "Mercedes has been upgrading it's cars since 2000";
            User user = new("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client");

            _news = new(title, text, user);
        }

        [Test, Combinatorial]
        public void TestConstructor_NewsIsInvalid_ThrowAnException(
            [Values(null, "", "  ")] string title,
            [Values(null, "", "  ")] string text,
            [Values(null)] User user)
        {
            Assert.Catch<Exception>(() => new News(title, text, user));
        }

        [Test]
        public void TestConstructor_NewsIsValid_ShouldConstructAnUser()
        {
            try
            {
                string title = "Mercedes";
                string text = "Mercedes has been upgrading it's cars since 2000";
                User user = new("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client");

                News news = new(title, text, user);

                Assert.IsNotNull(news);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test, Combinatorial]
        public void TestUpdate_WithInvalidArguments_ThrowAnException(
            [Values(null, "", " ")] string title,
            [Values(null, "", " ")] string text)
        {
            Assert.Catch<Exception>(() => _news.Update(title, text));
        }

        [Test]
        public void TestToNewsOutputViewModel_WhenCalled_PropertiesShouldBeSetCorrectly()
        {
            var vm = _news.ToNewsOutputViewModel();

            Assert.AreEqual(vm.Id, _news.Id);
            Assert.AreEqual(vm.PublishedBy, _news.Owner.Email);
            Assert.AreEqual(vm.Text, _news.Text);
            Assert.AreEqual(vm.Title, _news.Title);
            Assert.AreEqual(vm.UpdatedAt, _news.LastUpdate);
            Assert.AreEqual(vm.CreatedAt, _news.CreatedOn);
        }
    }
}
