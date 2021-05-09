using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.ViewModels.News;
using NUnit.Framework;

namespace ICar.Tests.Validations
{

    [TestFixture]
    class NewsValidatorTests
    {

        [Test]
        [TestCase("Home sweet home", "I arrived my home sweet home under protection")]
        [TestCase("Batman our hero", "Batman is fighting through the city to keep our people safe")]
        [TestCase("Iron man our hero", "Unfortunately iron man is dead, lets check what Marvel will do about it")]
        public void GetInvalidReasons_NewsIsValid_ReturnsNull(string title, string text)
        {
            NewNews news = new NewNews(title, text, null, null);
            var result = NewsValidator.GetInvalidReasonsForInsert(news);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("Home sweet home", "I arrived")]
        [TestCase("Home", "I arrived")]
        [TestCase("Batman", "Batman is...")]
        [TestCase("Iron", "Unfortunately iron")]
        [TestCase(null, null)]
        public void GetInvalidReasons_NewsIsInvalid_ReturnsAListOfInvalidReasons(string title, string text)
        {
            NewNews news = new NewNews(title, text, null, null);

            var result = NewsValidator.GetInvalidReasonsForInsert(news);

            Assert.That(result, Is.Not.Null);
        }
    }
}
