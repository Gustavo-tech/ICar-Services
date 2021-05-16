using ICar.Data.Models.Abstracts;

namespace ICar.Data.ViewModels.News
{
    public class NewNews : AbstractNews
    {
        public string Cnpj { get; set; }
        public string Cpf { get; set; }

        public NewNews(string title, string text, string cnpj, string cpf)
        {
            Title = title;
            Text = text;
            Cnpj = cnpj;
            Cpf = cpf;
        }
    }
}
