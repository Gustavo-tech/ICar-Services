using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class UserNews : AbstractNews
    {
        [Required(ErrorMessage = "{0} is required")]
        public string UserCpfFk { get; set; }

        public User PublishedBy { get; set; }

        public UserNews()
        { }

        public UserNews(string title, string text, User publishedBy)
        {
            Title = title;
            Text = text;
            PublishedBy = publishedBy;
        }

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
