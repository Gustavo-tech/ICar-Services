using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels.UserNews
{
    public class UserNewsViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, ErrorMessage = "{0} can't have more than {1} chars")]
        public string Title { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(500, ErrorMessage = "{0} can't have more than {1} chars")]
        public string Text { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} should have {1} characters")]
        [RegularExpression("[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", ErrorMessage = "This is not a CPF")]
        public string Cpf { get; }

        public UserNewsViewModel(string title, string text, string cpf)
        {
            Title = title;
            Text = text;
            Cpf = cpf;
        }
    }
}
