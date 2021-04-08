using System;

namespace ICar.Data.Models.Abstract
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public int NumberOfCarsSelling { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
    }
}
