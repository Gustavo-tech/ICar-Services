using ICar.Data.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Accounts
{
    public class User : Entity
    {

        [Key]
        public string Cpf { get; }
        public City City { get; set; }
    }
}
