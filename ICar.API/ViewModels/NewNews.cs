namespace ICar.API.ViewModels {
    public class NewNews {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        
        public NewNews(string title, string text, string cnpj, string cpf) {
            Title = title;
            Text = text;
            Cnpj = cnpj;
            Cpf = cpf;
        }
    }
}
