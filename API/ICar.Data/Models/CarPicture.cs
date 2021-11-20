using System;

namespace ICar.Infrastructure.Models
{
    public class CarPicture : Entity
    {
        public string Picture { get; set; }
        public Car Car { get; set; }

        private CarPicture()
        {
        }

        public CarPicture(string picture, Car car)
            : base()
        {
            if (string.IsNullOrWhiteSpace(picture))
                throw new ArgumentNullException(nameof(picture), "Picture content can't be null");

            Car = car ?? throw new ArgumentNullException(nameof(car), "Car argument can't be null");
            Picture = picture;
        }
    }
}
