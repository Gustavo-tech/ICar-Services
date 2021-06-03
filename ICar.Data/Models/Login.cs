using System;

namespace ICar.Infrastructure.Models
{
    public class Login
    {
        public int? Id { get; set; }
        public string Discrminator { get; set; }
        public DateTime Time { get; set; }

        public Login()
        { }

        public Login(string discriminator)
        {
            Discrminator = discriminator;
            Time = DateTime.Now;
        }
    }
}
