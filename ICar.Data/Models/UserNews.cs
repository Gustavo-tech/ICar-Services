using ICar.Infrastructure.Models.Abstracts;

namespace ICar.Infrastructure.Models
{
    public class UserNews : AbstractNews
    {
        public User PublishedBy { get; set; }

        public UserNews()
        { }
    }
}
