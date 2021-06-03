using System;

namespace ICar.Infrastructure.Models.Abstracts
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
    }
}
