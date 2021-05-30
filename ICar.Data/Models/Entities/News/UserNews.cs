using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class UserNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public string UserCpf { get; set; }
        public User PublishedBy { get; set; }

        public UserNews()
        { }

        public UserNews(string title, string text,
            DateTime createdOn, DateTime lastUpdate, User publishedBy)
        {
            Title = title;
            Text = text;
            CreatedOn = createdOn;
            LastUpdate = lastUpdate;
            PublishedBy = publishedBy;
        }
    }
}
