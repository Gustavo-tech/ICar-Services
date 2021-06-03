using System;

namespace ICar.Infrastructure.Models
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
