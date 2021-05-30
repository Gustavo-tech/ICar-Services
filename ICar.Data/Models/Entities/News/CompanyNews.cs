using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;

namespace ICar.Data.Models.Entities.News
{
    public class CompanyNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public string CompanyCnpj { get; set; }
        public Company PublishedBy { get; set; }

        public CompanyNews()
        { }

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
