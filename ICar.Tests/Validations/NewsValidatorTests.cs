using ICar.Data.Models;
using ICar.Data.Validations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Tests.Validations {

    [TestFixture]
    class NewsValidatorTests {

        [Test]
        [TestCase("Home sweet home", "I arrived my home sweet home under protection")]
        [TestCase("Batman our hero", "Batman is fighting through the city to keep our people safe")]
        [TestCase("Iron man our hero", "Unfortunately iron man is dead, lets check what Marvel will do about it")]
        public void GetInvalidReasons_NewsIsValid_ReturnsNull(string title, string text) {
            News news = new News(title, text, null, null);

            var result = NewsValidator.GetInvalidReasons(news);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("Home sweet home", "I arrived")]
        [TestCase("Home", "I arrived")]
        [TestCase("Batman", "Batman is...")]
        [TestCase("Iron", "Unfortunately iron")]
        [TestCase(null, null)]
        public void GetInvalidReasons_NewsIsInvalid_ReturnsAListOfInvalidReasons(string title, string text) {
            News news = new News(title, text, null, null);

            var result = NewsValidator.GetInvalidReasons(news);

            Assert.That(result, Is.Not.Null);
        }
    }
}
