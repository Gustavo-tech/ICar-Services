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
            string authorId = "Gustavo";

            _news = new(title, text, authorId);
        }

        [Test, Combinatorial]
        public void TestConstructor_NewsIsInvalid_ThrowAnException(
            [Values(null, "", "  ")] string title,
            [Values(null, "", "  ")] string text,
            [Values(null)] string authorId)
        {
            Assert.Catch<Exception>(() => new News(title, text, authorId));
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
            Assert.AreEqual(vm.Author, _news.AuthorId);
            Assert.AreEqual(vm.Text, _news.Text);
            Assert.AreEqual(vm.Title, _news.Title);
            Assert.AreEqual(vm.UpdatedAt, _news.UpdatedAt);
            Assert.AreEqual(vm.CreatedAt, _news.CreatedAt);
        }
    }
}
