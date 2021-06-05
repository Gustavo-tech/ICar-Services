using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels.Company
{
    public class CompanyViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "A CNPJ should contain 18 characters")]
        [RegularExpression("[0-9]{2}[.][0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}")]
        public string Cnpj { get; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; }

        [Required(ErrorMessage = "{0} is required")]
        public string Email { get; }

        [StringLength(maximumLength: int.MaxValue, MinimumLength = 8,
        ErrorMessage = "{0} should contain at least {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; }

        public CompanyViewModel(string cnpj, string name, string email,
            string password)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
