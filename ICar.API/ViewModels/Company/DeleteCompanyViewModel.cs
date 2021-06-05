using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.ViewModels.Company
{
    public class DeleteCompanyViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "A CNPJ should contain 18 characters")]
        [RegularExpression("[0-9]{2}[.][0-9]{3}.[0-9]{3}[/][0-9]{4}[-][0-9]{2}")]
        public string Cnpj { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 8,
        ErrorMessage = "{0} should contain at least {1} characters")]
        public string Password { get; }

        public DeleteCompanyViewModel(string cnpj, string password)
        {
            Cnpj = cnpj;
            Password = password;
        }
    }
}
