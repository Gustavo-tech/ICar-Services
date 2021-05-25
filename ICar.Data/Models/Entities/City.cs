using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        public City()
        { }

        public City(string name)
        {
            Name = name;
        }

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
