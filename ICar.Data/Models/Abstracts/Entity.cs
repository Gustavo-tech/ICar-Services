using ICar.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Abstracts
{
    public abstract class Entity
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.DateTime)]
        public DateTime AccountCreationDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "A role can't have more than 30 chars")]
        public string Role { get; set; }
    }
}
