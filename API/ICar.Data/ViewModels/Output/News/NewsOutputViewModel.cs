using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output.News
{
    public class NewsOutputViewModel
    {
        public string Id { get; private set; }
        public string PublishedBy { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public NewsOutputViewModel(string id, string publishedBy, string title, 
            string text, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            PublishedBy = publishedBy;
            Title = title;
            Text = text;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
