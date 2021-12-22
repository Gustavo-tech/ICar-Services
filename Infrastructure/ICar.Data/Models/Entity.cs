using System;

namespace ICar.Infrastructure.Models
{
    public class Entity
    {
        public string Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        protected string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
