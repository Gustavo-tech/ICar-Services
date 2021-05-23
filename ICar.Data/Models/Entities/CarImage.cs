using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public string CarPlate { get; set; }
    }
}
