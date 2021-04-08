using ICar.Data.Models;
using ICar.Data.Validations;
using NUnit.Framework;

namespace ICar.Tests.Validations
{
    [TestFixture]
    class UserValidatorTests
    {
        [Test]
        public void TestValidateUser_UserIsValid_ReturnsTrue()
        {
            User user = new User("Gustavo", "gustavo@gmail.com", "hdsaj1%dsa", 
                "Vancouver", "198.768.987-89");
            UserValidator userValidator = new UserValidator();

            var result = userValidator.ValidateEntity(user);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestValidateUser_UserIsInvalid_ReturnsFalse()
        {
            User user = new User("Gus", "gustavo@.com", "hdsaj1%dsa",
                "vancouver", "198.76.98-89");
            UserValidator userValidator = new UserValidator();

            var result = userValidator.ValidateEntity(user);

            Assert.That(result, Is.False);
        }
    }
}
