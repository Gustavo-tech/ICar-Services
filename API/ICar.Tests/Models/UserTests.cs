using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    public class UserTests
    {
        [Test]
        [TestCase(null, null, null, null)]
        [TestCase(" ", " ", " ", " ")]
        [TestCase("", "", "", "")]
        public void TestUserConstructor_ArgumentIsInvalid_ThrowsException(string name, string phone, string email, string role)
        {
            Assert.Throws<InvalidOperationException>(() => new User(name, phone, email, role));
        }

        [Test]
        [TestCase("a", "a", "a", "a")]
        [TestCase("a", "(19) 83213(2912", "a", "a")]
        public void TestUserConstructor_ArgumentIsNotWellFormatted_ThrowsException(string name, string phone,
            string email, string role)
        {
            Assert.Throws<FormatException>(() => new User(name, phone, email, role));
        }

        [Test]
        [TestCase("Gustavo", "(19) 83213-2912", "dss@gmail.com", "client")]
        [TestCase("Bryan", "(19) 32213-2912", "dss@gmail.com", "client")]
        public void TestUserConstructor_ArgumentsAreValid_ConstructsAnUser(string name, string phone, string email, string role)
        {
            User user = new(name, phone, email, role);

            Assert.IsNotNull(user);
        }
    }
}
