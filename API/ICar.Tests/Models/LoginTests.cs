using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    class LoginTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new()
            {
                UserName = "Gustavo",
                Email = "gustavo@gmail.com",
                Role = "admin"
            };
        }

        [Test]
        public void TestGenerateSuccessfulLogin_CalledWithNullUser_ThrowAnException()
        {
            Assert.Catch<Exception>(() => Login.GenerateSuccessfulLogin(null));
        }

        [Test]
        public void TestGenerateFailedLogin_CalledWithNullUser_ThrowAnExceptiond()
        {
            Assert.Catch<Exception>(() => Login.GenerateFailedLogin(null));
        }

        [Test]
        public void TestGenerateSuccessfulLogin_CalledWithAnUser_GenerateALoginWithSuccess()
        {
            var result = Login.GenerateSuccessfulLogin(_user);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void TestGenerateFailedLogin_CalledWithAnUser_GenerateALoginWithFailed()
        {
            var result = Login.GenerateFailedLogin(_user);

            Assert.IsFalse(result.Success);
        }
    }
}
