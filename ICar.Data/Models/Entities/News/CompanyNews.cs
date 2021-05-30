using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;

namespace ICar.Data.Models.Entities.News
{
    public class CompanyNews : AbstractNews
    {
        public Company PublishedBy { get; set; }

        public CompanyNews()
        { }
    }
}
