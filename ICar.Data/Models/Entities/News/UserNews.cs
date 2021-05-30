using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class UserNews : AbstractNews
    {
        public User PublishedBy { get; set; }

        public UserNews()
        { }
    }
}
