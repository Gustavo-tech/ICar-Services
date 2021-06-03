using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Models.Abstracts
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Role { get; set; }
        public List<News> News { get; set; }
        public List<Login> Logins { get; set; }
        public List<Car> Cars { get; set; }
    }
}
