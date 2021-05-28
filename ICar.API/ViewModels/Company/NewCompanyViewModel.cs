using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels
{
    public class NewCompanyViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "A CNPJ should contain 18 characters")]
        public string Cnpj { get; }
        
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} is not an email")]
        public string Email { get; }

        [DataType(DataType.Password)]
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 8,
        ErrorMessage = "{0} should contain at least {1} characters")]
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; }

        [Required(ErrorMessage = "{0} is required")]
        public List<string> Cities { get; }

        public NewCompanyViewModel(string cnpj, string name, string email, string password, List<string> cities)
        {
            Cnpj = cnpj;
            Name = name;
            Email = email;
            Password = password;
            Cities = cities;
        }
    }
}
