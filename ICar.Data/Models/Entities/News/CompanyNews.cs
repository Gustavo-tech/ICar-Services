using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class CompanyNews : AbstractNews
    {
        [Required(ErrorMessage = "{0} is required")]
        public Company PublishedBy { get; set; }

        public CompanyNews(string title, string text,
            DateTime createdOn, DateTime lastUpdate, Company publishedBy)
        {
            Title = title;
            Text = text;
            CreatedOn = createdOn;
            LastUpdate = lastUpdate;
            PublishedBy = publishedBy;
        }
    }
}
