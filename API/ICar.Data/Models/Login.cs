using System;

namespace ICar.Infrastructure.Database.Models
{
    public class Login
    {
        public int? Id { get; set; }
        public DateTime Time { get; set; }

        public User User { get; set; }

        public Login()
        { }
    }
}
