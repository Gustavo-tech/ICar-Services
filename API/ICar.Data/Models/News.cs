﻿using System;

namespace ICar.Infrastructure.Database.Models
{
    public class News
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }

        public User Owner { get; set; }

        public News()
        { }

        public News(string title, string text)
        {
            Title = title;
            Text = text;
            CreatedOn = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }
}
