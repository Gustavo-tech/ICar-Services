using ICar.Data.Models.Entities.Cars;

namespace ICar.Data.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public UserCar UserCar { get; set; }
        public CompanyCar CompanyCar { get; set; }
        public CarImage()
        { }
    }
}
