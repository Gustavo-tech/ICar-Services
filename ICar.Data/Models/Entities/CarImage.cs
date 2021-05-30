using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;

namespace ICar.Data.Models.Entities
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageStream { get; set; }
        public string CarPlate { get; set; }
        public UserCar UserCar { get; set; }
        public CompanyCar CompanyCar { get; set; }

        public CarImage()
        { }

        public CarImage(int id, string imageStream, string carPlate, UserCar userCar, CompanyCar companyCar)
        {
            Id = id;
            ImageStream = imageStream;
            CarPlate = carPlate;
            UserCar = userCar;
            CompanyCar = companyCar;
        }
    }
}
