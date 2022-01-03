using ICar.Infrastructure.Models;
using ICar.Infrastructure.ViewModels.Input;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Tests.Models
{
    class ContactTests
    {
        private Contact _contact;

        [SetUp]
        public void SetUp()
        {
            _contact = new("1b341fcc-5e21-45bd-ba52-872426b36da3", "Gustavo", "Faria", 
                "+55 19 99999-9999", "gustavo@gmail.com");
        }

        [Test]
        [TestCase("+55 19 99999-9999")]
        [TestCase("+55 19 98888-8888")]
        [TestCase("+55 19 97777-7777")]
        public void TestUpdatePhoneNumber_EachFieldIndividuallyOverload_UpdatesContactProperties(string phoneNumber)
        {
            _contact.UpdatePhoneNumber(phoneNumber);

            Assert.AreEqual(phoneNumber, _contact.PhoneNumber);
        }

        [Test]
        [TestCase("+55 19 99999-9999")]
        [TestCase("+55 19 98888-8888")]
        [TestCase("+55 19 97777-7777")]
        public void TestUpdate_ViewModelOverload_UpdatesContactProperties(string phoneNumber)
        {
            UpdatePhoneViewModel viewModel = new()
            {
                PhoneNumber = phoneNumber,
            };

            _contact.UpdatePhoneNumber(viewModel);

            Assert.AreEqual(phoneNumber, _contact.PhoneNumber);
        }
    }
}
