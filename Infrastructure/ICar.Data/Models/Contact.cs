using System;
using System.Net.Mail;

namespace ICar.Infrastructure.Models
{
    public class Contact
    {
        private string _emailAddress;
        private string _nickname;
        private string _phoneNumber;
        private string _userObjectId;

        public string UserObjectId
        {
            get { return _userObjectId; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 36)
                    throw new Exception("Invalid user object id");

                _userObjectId = value;
            }
        }

        public string Nickname
        {
            get { return _nickname; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 60)
                    throw new Exception("Nickname is invalid");

                _nickname = value;
            }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                MailAddress mailAddress = new(value);
                _emailAddress = mailAddress.Address;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new Exception("Invalid phone number");

                _phoneNumber = value;
            }
        }

        private Contact()
        {
        }

        public Contact(string userObjectId, string nickname, string phoneNumber,
            string emailAddress)
        {
            UserObjectId = userObjectId;
            Nickname = nickname;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
