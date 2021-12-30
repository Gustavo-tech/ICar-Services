using ICar.Infrastructure.ViewModels.Output;
using System;

namespace ICar.Infrastructure.Models
{
    public class News : Entity
    {
        private string _title;
        private string _text;
        private string _authorId;

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

        public string AuthorId
        {
            get { return _authorId; }
            private set
            {
                if (value is null)
                    throw new Exception("Owner must not be null");

                _authorId = value;
            }
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private News()
        {
        }

        public News(string title, string text, string authorId)
            : base()
        {
            Title = title;
            Text = text;
            AuthorId = authorId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public News Update(string title, string text)
        {
            Title = title;
            Text = text;
            UpdatedAt = DateTime.Now;
            return this;
        }

        public NewsOutputViewModel ToNewsOutputViewModel()
        {
            return new NewsOutputViewModel(Id, AuthorId, Title, Text, CreatedAt, UpdatedAt);
        }
    }
}
