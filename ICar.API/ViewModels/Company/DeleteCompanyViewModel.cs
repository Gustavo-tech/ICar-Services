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
        public string Email { get; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 8,
        ErrorMessage = "{0} should contain at least {1} characters")]
        public string Password { get; }

        public DeleteCompanyViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
