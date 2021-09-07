using System;

namespace ICar.Infrastructure.Models
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
