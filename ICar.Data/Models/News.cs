using System;

namespace ICar.Infrastructure.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CompanyCnpj { get; set; }
        public string UserCpf { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }

        public News()
        { }
    }
}
