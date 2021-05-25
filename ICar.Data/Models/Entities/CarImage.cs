using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public string CarPlateFk { get; set; }

        public CarImage()
        { }

        public CarImage(int id, string imageStream)
        {
            Id = id;
            ImageStream = imageStream;
        }
    }
}
