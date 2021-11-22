using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;

namespace ICar.Infrastructure.Tests.Models
{
    class LoginTests
    {
        private User _user;
        private Login _login;

        [SetUp]
        public void SetUp()
        {
            _user = new("Gustavo", "(11) 99822-0982", "gustavo@gmail.com", "admin");

            _login = Login.GenerateSuccessfulLogin(_user);
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

        [Test]
        public void TestGenerateLoginOutputViewModel_WhenCalled_GenerateLoginOutputViewModel()
        {
            var vm = _login.GenerateLoginOutputViewModel();

            Assert.AreEqual(vm.Id, _login.Id);
            Assert.AreEqual(vm.Success, _login.Success);
            Assert.AreEqual(vm.Time, _login.Time);
        }
    }
}
