namespace ICar.Data.Models.Entities
{
    public class News
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }

        public News(string title, string text, string cnpj, string cpf)
        {
            Title = title;
            Text = text;
            Cnpj = cnpj;
            Cpf = cpf;
        }
    }
}
