using ICar.Infrastructure.Models.Enums.Car;
using ICar.Infrastructure.ViewModels.Input.Car;
using ICar.Infrastructure.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Models
{
    public class Car : Entity
    {
        private string _plate;
        private string _maker;
        private string _model;
        private int _makeDate;
        private int _makedDate;
        private int _kilometersTraveled;
        private int _price;
        private string _message;

        public string Plate
        {
            get { return _plate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Plate is empty");

                else if (!Regex.IsMatch(value, "[A-Z]{3}[-][0-9]{4}"))
                    throw new Exception("Plate is not well formatted");

                _plate = value;
            }
        }

        public string Maker
        {
            get { return _maker; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Maker is empty");

                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                TextInfo ti = ci.TextInfo;

                _maker = ti.ToTitleCase(value);
            }
        }

        public string Model
        {
            get { return _model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Maker is empty");

                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                TextInfo ti = ci.TextInfo;

                _model = ti.ToTitleCase(value);
            }
        }

        public int MakeDate
        {
            get { return _makeDate; }
            private set
            {
                int currentYear = DateTime.Now.Year;

                if (value <= currentYear - 80)
                    throw new Exception("Invalid make date");

                _makeDate = value;
            }
        }

        public int MakedDate
        {
            get { return _makedDate; }
            private set
            {
                int currentYear = DateTime.Now.Year;

                if (value <= currentYear - 80)
                    throw new Exception("Invalid make date");

                _makedDate = value;
            }
        }

        public int KilometersTraveled
        {
            get { return _kilometersTraveled; }
            private set
            {
                if (value < 0)
                    throw new Exception("Kilometers traveled can't be less than zero");

                _kilometersTraveled = value;
            }
        }

        public int Price
        {
            get { return _price; }
            private set
            {
                if (value < 1000)
                    throw new Exception("Price must be greater than 999");

                _price = value;
            }
        }

        public string Message
        {
            get { return _message; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _message = "";

                _message = value;
            }
        }

        public string Color { get; private set; }
        public int NumberOfViews { get; private set; }
        public bool AcceptsChange { get; private set; }
        public bool IpvaIsPaid { get; private set; }
        public bool IsLicensed { get; private set; }
        public bool IsArmored { get; private set; }
        public ExchangeType ExchangeType { get; private set; }
        public GasolineType GasolineType { get; private set; }

        public string OwnerId { get; private set; }
        public Address Address { get; private set; }
        public List<CarPicture> Pictures { get; private set; } = new List<CarPicture>();

        private Car()
        {
        }

        public Car(string plate, string maker, string model,
            int makeDate, int makedDate, int kilometersTraveled,
            int price, string message, string color,
            ExchangeType exchangeType, GasolineType gasolineType, string ownerId,
            string[] pictures, Address address, bool acceptsChange = false,
            bool ipvaIsPaid = false, bool isLicensed = false, bool isArmored = false)
        {
            Plate = plate;
            Maker = maker;
            Model = model;
            MakeDate = makeDate;
            MakedDate = makedDate;
            KilometersTraveled = kilometersTraveled;
            Price = price;
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            IsArmored = isArmored;
            Message = message;
            ExchangeType = exchangeType;
            Color = color;
            GasolineType = gasolineType;
            OwnerId = ownerId;
            Address = address;
            GenerateCarPictures(pictures);
        }

        public Car IncreaseNumberOfViews()
        {
            NumberOfViews++;
            return this;
        }

        public async Task<Car> UpdateAddress(string zipCode, string location, string district, string street)
        {
            Address address = await Address.BuildAddress(zipCode, location, district, street);
            Address = address;
            return this;
        }

        public Car UpdateBooleanProperties(bool acceptsChange, bool ipvaIsPaid, bool isLicensed, bool isArmored)
        {
            AcceptsChange = acceptsChange;
            IpvaIsPaid = ipvaIsPaid;
            IsLicensed = isLicensed;
            IsArmored = isArmored;
            return this;
        }

        public Car UpdateMessage(string message)
        {
            Message = message;
            return this;
        }

        public Car UpdatePrice(int price)
        {
            Price = price;
            return this;
        }

        public Car UpdateKilometersTraveled(int kilometers)
        {
            KilometersTraveled = kilometers;
            return this;
        }

        public Car UpdatePictures(string[] pictures)
        {
            Pictures.Clear();
            GenerateCarPictures(pictures);
            return this;
        }

        public Car GenerateCarPictures(string[] pictures)
        {
            foreach (string pic in pictures)
            {
                CarPicture cp = new(OwnerId, Id, pic);
                Pictures.Add(cp);
            }

            return this;
        }

        public string GeneratePictureStoragePath()
        {
            return $"{OwnerId}/cars/{Id}";
        }

        public CarOverviewViewModel GenerateOverviewViewModel()
        {
            return new CarOverviewViewModel(Id, Maker, Model, MakeDate, MakedDate,
                Price, NumberOfViews, KilometersTraveled, Pictures.Select(x => x.PictureUrl).ToArray(), Address);
        }

        public async static Task<Car> GenerateWithInsertCarViewModel(InsertCarViewModel vm, string ownerId)
        {
            if (vm is null || vm.Address is null)
                throw new Exception("Invalid view model");

            if (string.IsNullOrWhiteSpace(ownerId))
                throw new ArgumentNullException(nameof(ownerId), "Owner must not be null");

            Car car = new
            (
                vm.Plate,
                vm.Maker,
                vm.Model,
                vm.MakeDate,
                vm.MakedDate,
                vm.KilometersTraveled,
                vm.Price,
                vm.Message,
                vm.Color,
                ConvertStringToTypeOfExchange(vm.ExchangeType),
                ConvertStringToGasolineType(vm.GasolineType),
                ownerId,
                vm.Pictures,
                await Address.BuildAddress(vm.Address.ZipCode, vm.Address.Location, vm.Address.District, vm.Address.Street),
                vm.AcceptsChange,
                vm.IpvaIsPaid,
                vm.IsLicensed,
                vm.IsArmored
            );

            return car;
        }

        public static ExchangeType ConvertStringToTypeOfExchange(string typeOfExchange)
        {
            typeOfExchange = typeOfExchange.ToLower();
            switch (typeOfExchange)
            {
                case "automatic":
                    return ExchangeType.Automatic;
                case "manual":
                    return ExchangeType.Manual;
                default:
                    throw new Exception("Invalid argument");
            }
        }
        public static string ConvertTypeOfExchangeToString(ExchangeType typeOfExchange)
        {
            switch (typeOfExchange)
            {
                case ExchangeType.Automatic:
                    return "automatic";
                case ExchangeType.Manual:
                    return "manual";
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static GasolineType ConvertStringToGasolineType(string gasolineType)
        {
            gasolineType = gasolineType.ToLower();
            switch (gasolineType)
            {
                case "gasoline":
                    return GasolineType.Gasoline;
                case "eletric":
                    return GasolineType.Eletric;
                case "flex":
                    return GasolineType.Flex;
                case "diesel":
                    return GasolineType.Diesel;
                default:
                    throw new Exception("Invalid argument");
            }
        }

        public static string ConvertGasolineTypeToString(GasolineType gasolineType)
        {
            switch (gasolineType)
            {
                case GasolineType.Diesel:
                    return "diesel";
                case GasolineType.Gasoline:
                    return "gasoline";
                case GasolineType.Eletric:
                    return "eletric";
                case GasolineType.Flex:
                    return "flex";
                default:
                    throw new Exception("Invalid argument");
            }
        }
    }
}
