using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Abstracts
{
    public abstract class AbstractNews
    {
        [Key]
        public int Id { get; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(60, ErrorMessage = "A title can't have more than 60 chars")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(400, ErrorMessage = "A text can't have more than 400 chars")]
        public string Text { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastUpdate { get; set; }
    }
}
