using System;

namespace ICar.Infrastructure.Models
{
    public class Entity
    {
        public string Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
