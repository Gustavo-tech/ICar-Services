namespace ICar.Data.ViewModels.News
{
    public class UpdatedNews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public UpdatedNews(int id, string title, string text)
        {
            Id = id;
            Title = title;
            Text = text;
        }
    }
}
