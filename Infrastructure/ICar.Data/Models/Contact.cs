using ICar.Infrastructure.ViewModels.Input;
using System;
using System.Net.Mail;

namespace ICar.Infrastructure.Models
{
    public class Contact
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
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

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                try
                {
                    MailAddress mail = new(value);
                    _emailAddress = mail.Address;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 60)
                    throw new Exception("Nickname is invalid");

                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 60)
                    throw new Exception("Nickname is invalid");

                _lastName = value;
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

        public Contact(string userObjectId, string email, string firstName, string lastName, 
            string phoneNumber)
        {
            UserObjectId = userObjectId;
            EmailAddress = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void UpdatePhoneNumber(UpdatePhoneViewModel updateContact)
        {
            if (updateContact is null)
                return;

            PhoneNumber = updateContact.PhoneNumber;
        }
    }
}
