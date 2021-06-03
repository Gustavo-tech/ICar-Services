using System;

namespace ICar.Infrastructure.Models
{
    public class Login
    {
        public int? Id { get; set; }
        public string Discriminator { get; set; }
        public DateTime Time { get; set; }

        public Login()
        { }

        public Login(string discriminator)
        {
            Discriminator = discriminator;
            Time = DateTime.Now;
        }
    }
}
