using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels.CompayNews
{
    public class CompanyNewsViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, ErrorMessage = "{0} can't have more than {1} chars")]
        public string Title { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(500, ErrorMessage = "{0} can't have more than {1} chars")]
        public string Text { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "A CNPJ should contain 18 characters")]
        [RegularExpression("[0-9]{2}[.][0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}")]
        public string CompanyCnpj { get; }

        public CompanyNewsViewModel(string title, string text, string companyCnpj)
        {
            Title = title;
            Text = text;
            CompanyCnpj = companyCnpj;
        }
    }
}
