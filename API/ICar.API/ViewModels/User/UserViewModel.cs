﻿using System.ComponentModel.DataAnnotations;

namespace ICar.API.ViewModels.User
{
    public sealed class UserViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "{0} should have {1} characters")]
        [RegularExpression("[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}", ErrorMessage = "This is not a CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "{0} should have at least {2} characters")]
        public string Name { get; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; }

        public UserViewModel(string cpf, string name, string email, string password)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}