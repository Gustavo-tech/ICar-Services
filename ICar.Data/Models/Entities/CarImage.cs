using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public string CarPlate { get; set; }

        public CarImage()
        { }

        public CarImage(int id, string imageStream, string carPlate)
        {
            Id = id;
            ImageStream = imageStream;
            CarPlate = carPlate;
        }
    }
}
