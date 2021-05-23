using ICar.API.Validations;
using ICar.Data.Models.Entities.Accounts;
using NUnit.Framework;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class UserValidatorTests
    {
        [Test]
        public void TestValidateUser_UserIsValid_ReturnsTrue()
        {
            User user = new User("198.768.987-89", "Gustavo", "gustavo78@gmail.com", "hdsaj1%dsa", "Vancouver");

            var result = UserValidator.GetInvalidReasonsForInsert(user);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestValidateUser_UserIsInvalid_ReturnsFalse()
        {
            User newUser = new User("198.76.98-89", "Gus", "gustavo@.com", "hdsaj1%dsa", "vancouver");

            var result = UserValidator.GetInvalidReasonsForInsert(newUser);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
