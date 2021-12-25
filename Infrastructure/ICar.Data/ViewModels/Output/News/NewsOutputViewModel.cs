using System;

namespace ICar.Infrastructure.ViewModels.Output.News
{
    public class NewsOutputViewModel
    {
        public string Id { get; private set; }
        public string AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public NewsOutputViewModel()
        {
        }

        public NewsOutputViewModel(string id, string authorId, string title, 
            string text, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
            Text = text;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
