using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Accounts;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class UserNews : AbstractNews
    {
        [Required(ErrorMessage = "{0} is required")]
        public User PublishedBy { get; set; }
    }
}
