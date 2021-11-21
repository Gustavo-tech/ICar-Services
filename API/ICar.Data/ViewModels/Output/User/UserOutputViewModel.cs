using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output.User
{
    public class UserOutputViewModel
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime AccountCreationDate { get; private set; }

        public UserOutputViewModel(string userName, string email, string role, DateTime accountCreationDate)
        {
            UserName = userName;
            Email = email;
            Role = role;
            AccountCreationDate = accountCreationDate;
        }
    }
}
