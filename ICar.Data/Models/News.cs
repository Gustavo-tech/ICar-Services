namespace ICar.Data.Models
{
    public class News
    {
        public int Id { get; }
        public string Title { get; }
        public string Text { get; }
        public User User { get; set; }
        public Company Company { get; set; }
    }
}
