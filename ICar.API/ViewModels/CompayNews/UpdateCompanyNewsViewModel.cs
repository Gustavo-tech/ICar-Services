﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.ViewModels.CompayNews
{
    public class UpdateCompanyNewsViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public int Id { get; }

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

        public UpdateCompanyNewsViewModel(int id, string title, string text, string companyCnpj)
        {
            Id = id;
            Title = title;
            Text = text;
            CompanyCnpj = companyCnpj;
        }
    }
}