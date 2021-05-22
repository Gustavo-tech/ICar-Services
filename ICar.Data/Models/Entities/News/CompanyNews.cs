using ICar.Data.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.News
{
    public class CompanyNews : AbstractNews
    {
        [Required(ErrorMessage = "{0} is required")]
        public CompanyNews PublishedBy { get; set; }
    }
}
