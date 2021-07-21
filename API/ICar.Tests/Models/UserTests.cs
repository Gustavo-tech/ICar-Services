using ICar.Infrastructure.Database.Models;
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
        [TestCase(null, null, null, null, null)]
        [TestCase(" ", " ", " ", " ", " ")]
        [TestCase("", "", "", "", "")]
        public void TestUserConstructor_ArgumentIsInvalid_ThrowsException(string cpf, string name, string phone,
            string email, string role)
        {
            Assert.Throws<InvalidOperationException>(() => new User(cpf, name, phone, email, role));
        }

        [Test]
        [TestCase("303.922-099.22", "a", "a", "a", "a")]
        [TestCase("303.202.212-21", "a", "(19) 83213(2912", "a", "a")]
        public void TestUserConstructor_ArgumentIsNotWellFormatted_ThrowsException(string cpf, string name, string phone,
            string email, string role)
        {
            Assert.Throws<FormatException>(() => new User(cpf, name, phone, email, role));
        }

        [Test]
        [TestCase("303.922-099.22", "Gustavo", "(19) 83213-2912", "dss@gmail.com", "client")]
        [TestCase("910.724-321.90", "Bryan", "(19) 32213-2912", "dss@gmail.com", "client")]
        public void TestUserConstructor_ArgumentsAreValid_ConstructsAnUser(string cpf, string name, string phone,
            string email, string role)
        {
            Assert.Throws<FormatException>(() => new User(cpf, name, phone, email, role));
        }
    }
}
