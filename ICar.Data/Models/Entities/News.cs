using System;

namespace ICar.Data.Models {
    public class News {
        public int Id { get; }
        public string Title { get; }
        public string Text { get; }
        public DateTime LastUpdate { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }

        public News(string title, string text, User user, Company company) {
            Title = title;
            Text = text;
            User = user;
            Company = company;
        }

        public News(int id, string title, string text, DateTime lastUpdate, User user, Company company) {
            Id = id;
            Title = title;
            Text = text;
            LastUpdate = lastUpdate;
            User = user;
            Company = company;
        }
    }
}
