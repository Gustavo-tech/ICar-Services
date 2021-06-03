using ICar.Infrastructure.Models.Abstracts;

namespace ICar.Infrastructure.Models
{
    public class CompanyNews : News
    {
        public Company PublishedBy { get; set; }

        public CompanyNews()
        { }
    }
}
