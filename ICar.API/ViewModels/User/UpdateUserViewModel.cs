using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels.User
{
    public class UpdateUserViewModel
    {
        [RegularExpression("[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", ErrorMessage = "This is not a CPF")]
        public string Cpf { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} must have at least {2} characters")]
        public string Name { get; }

        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; }

        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; }

        public UpdateUserViewModel(string cpf, string name, string email, string city, string password)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
