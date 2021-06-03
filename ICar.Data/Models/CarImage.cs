namespace ICar.Infrastructure.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public Car Car { get; set; }
        public CarImage()
        { }
    }
}
