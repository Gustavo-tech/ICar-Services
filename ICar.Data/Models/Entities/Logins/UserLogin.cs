using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Logins
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public User User { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
    }
}
