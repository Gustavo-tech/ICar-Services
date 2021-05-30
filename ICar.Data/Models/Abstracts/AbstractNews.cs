using System;

namespace ICar.Data.Models.Abstracts
{
    public abstract class AbstractNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
