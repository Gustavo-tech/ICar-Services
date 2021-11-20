using System;

namespace ICar.Infrastructure.Models
{
    public class News : Entity
    {
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime LastUpdate { get; private set; }

        public User Owner { get; private set; }

        private News()
        { 
        }

        public News(string title, string text)
            : base()
        {
            Title = title;
            Text = text;
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }

        public News Update(string title, string text)
        {
            Title = title;
            Text = text;
            LastUpdate = DateTime.Now;
            return this;
        }

        public dynamic GenerateApiOutput()
        {
            return new
            {
                Id,
                PublishedBy = Owner.Email,
                Title,
                Text,
                LastUpdate,
                CreatedOn
            };
        }
    }
}
