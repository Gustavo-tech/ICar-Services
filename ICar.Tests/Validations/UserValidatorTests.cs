using ICar.API.Validations;
using ICar.Data.Models.Entities;
using NUnit.Framework;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class UserValidatorTests
    {
        [Test]
        public void TestValidateUser_UserIsValid_ReturnsTrue()
        {
            UserValidator userValidator = new UserValidator();
            User user = new User("198.768.987-89", "gustavo@gmail.com", "Gustavo", "hdsaj1%dsa", "Vancouver");

            var result = userValidator.GetInvalidReasonsForInsert(user);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestValidateUser_UserIsInvalid_ReturnsFalse()
        {
            User newUser = new User("Gus", "gustavo@.com", "hdsaj1%dsa",
                "vancouver", "198.76.98-89");
            UserValidator userValidator = new UserValidator();

            var result = userValidator.GetInvalidReasonsForInsert(newUser);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
