using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;

namespace ICar.Data.Models.Entities.News
{
    public class UserNews : AbstractNews
    {
        public User PublishedBy { get; set; }

        public UserNews()
        { }
    }
}
