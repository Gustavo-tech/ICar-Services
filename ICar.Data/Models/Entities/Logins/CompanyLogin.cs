using ICar.Data.Models.Entities.Accounts;
using System;

namespace ICar.Data.Models.Entities.Logins
{
    public class CompanyLogin
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public DateTime Time { get; set; }

        public CompanyLogin()
        { }
    }
}
