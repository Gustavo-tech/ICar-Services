using System;

namespace ICar.Infrastructure.Models
{
    public class News : Entity
    {
        private string _title;
        private string _text;
        private User _owner;

        public string Title 
        { 
            get { return _title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Title must not be empty");

                _title = value;
            }
        }

        public string Text 
        { 
            get { return _text; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Text must not be empty");

                _text = value;
            }
        }

        public User Owner
        {
            get { return _owner; }
            private set 
            {
                if (value is null)
                    throw new Exception("Owner must not be null");

                _owner = value;
            }
        }


        public DateTime CreatedOn { get; private set; }
        public DateTime LastUpdate { get; private set; }

        private News()
        { 
        }

        public News(string title, string text, User owner)
            : base()
        {
            Title = title;
            Text = text;
            Owner = owner;
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
