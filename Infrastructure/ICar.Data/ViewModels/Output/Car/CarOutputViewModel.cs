using ICar.Infrastructure.Models;
using System.Linq;

namespace ICar.Infrastructure.ViewModels.Output
{
    public class CarOutputViewModel
    {
        public string Id { get; internal set; }
        public string Plate { get; internal set; }
        public string Maker { get; internal set; }
        public string Model { get; internal set; }
        public string Message { get; internal set; }
        public string TypeOfExchange { get; internal set; }
        public string Color { get; internal set; }
        public string GasolineType { get; internal set; }
        public int MakeDate { get; internal set; }
        public int MakedDate { get; internal set; }
        public int KilometersTraveled { get; internal set; }
        public int Price { get; internal set; }
        public int NumberOfViews { get; internal set; }
        public bool AcceptsChange { get; internal set; }
        public bool IpvaIsPaid { get; internal set; }
        public bool IsLicensed { get; internal set; }
        public bool IsArmored { get; internal set; }
        public string[] Pictures { get; internal set; }

        public string OwnerId { get; internal set; }
        public Address Address { get; internal set; }
        public ContactInfo Contact { get; internal set; }

        private CarOutputViewModel()
        {

        }

        public static CarOutputViewModel GenerateCarOutputViewModelWithCar(Models.Car car, Contact contact)
        {
            if (car is null)
                return null;

            return new CarOutputViewModel()
            {
                Id = car.Id,
                AcceptsChange = car.AcceptsChange,
                Address = car.Address,
                Color = car.Color,
                GasolineType = Models.Car.ConvertGasolineTypeToString(car.GasolineType),
                IpvaIsPaid = car.IpvaIsPaid,
                IsArmored = car.IsArmored,
                IsLicensed = car.IsLicensed,
                KilometersTraveled = car.KilometersTraveled,
                MakeDate = car.MakeDate,
                MakedDate = car.MakedDate,
                Maker = car.Maker,
                Message = car.Message,
                Model = car.Model,
                NumberOfViews = car.NumberOfViews,
                OwnerId = car.OwnerId,
                Pictures = car.Pictures.Select(x => x.PictureUrl).ToArray(),
                Plate = car.Plate,
                Price = car.Price,
                TypeOfExchange = Models.Car.ConvertTypeOfExchangeToString(car.ExchangeType),
                Contact = new ContactInfo()
                {
                    EmailAddress = contact.EmailAddress,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    PhoneNumber = contact.PhoneNumber
                }
            };
        }
    }

    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
