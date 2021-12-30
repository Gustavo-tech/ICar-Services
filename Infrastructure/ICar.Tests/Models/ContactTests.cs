using ICar.Infrastructure.Models;
using ICar.Infrastructure.ViewModels.Input.Contact;
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
            _contact = new("1b341fcc-5e21-45bd-ba52-872426b36da3", "Gustavo", "+55 19 99999-9999", "gustavo@gmail.com");
        }

        [Test, Combinatorial]
        public void TestUpdate_EachFieldIndividuallyOverload_UpdatesContactProperties(
            [Values("gustavo@gmail.com", "james@gmail.com", "slash@gmail.com")] string email,
            [Values("Gustavo", "James", "Slash")] string nickname,
            [Values("+55 19 99999-9999", "+55 19 98888-8888", "+55 19 97777-7777")] string phoneNumber)
        {
            _contact.Update(nickname, phoneNumber, email);

            Assert.AreEqual(nickname, _contact.Nickname);
            Assert.AreEqual(email, _contact.EmailAddress);
            Assert.AreEqual(phoneNumber, _contact.PhoneNumber);
        }

        [Test, Combinatorial]
        public void TestUpdate_ViewModelOverload_UpdatesContactProperties(
            [Values("gustavo@gmail.com", "james@gmail.com", "slash@gmail.com")] string email,
            [Values("Gustavo", "James", "Slash")] string nickname,
            [Values("+55 19 99999-9999", "+55 19 98888-8888", "+55 19 97777-7777")] string phoneNumber)
        {
            UpdateContactViewModel viewModel = new()
            {
                PhoneNumber = phoneNumber,
                EmailAddress = email,
                Nickname = nickname
            };

            _contact.Update(viewModel);

            Assert.AreEqual(nickname, _contact.Nickname);
            Assert.AreEqual(email, _contact.EmailAddress);
            Assert.AreEqual(phoneNumber, _contact.PhoneNumber);
        }
    }
}
