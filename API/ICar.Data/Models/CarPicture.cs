using System;

namespace ICar.Infrastructure.Database.Models
{
    public class CarPicture
    {
        public int? Id { get; set; }
        public string Picture { get; set; }
        public Car Car { get; set; }

        public CarPicture()
        {
        }

        public CarPicture(string picture, Car car)
        {
            if (string.IsNullOrWhiteSpace(picture))
                throw new ArgumentNullException(nameof(picture), "Picture content can't be null");

            if (car == null)
                throw new ArgumentNullException(nameof(car), "Car argument can't be null");

            Picture = picture;
            Car = car;
        }
    }
}
