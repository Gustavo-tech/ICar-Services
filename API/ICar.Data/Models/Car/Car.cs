using ICar.Infrastructure.Models.Enums.Car;
using ICar.Infrastructure.ViewModels.Input.Car;
using ICar.Infrastructure.ViewModels.Output.Car;
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

        public Address Address { get; private set; }
        public User Owner { get; private set; }
        public List<CarPicture> Pictures { get; private set; } = new List<CarPicture>();

        private Car()
            : base()
        {
        }

        public Car(string plate, string maker, string model,
            int makeDate, int makedDate, int kilometersTraveled,
            int price, string message, string color,
            ExchangeType exchangeType, GasolineType gasolineType, User owner,
            Address address, string[] pictures, bool acceptsChange = false,
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
            Owner = owner;
            Address = address;
            GenerateCarPictures(pictures);
        }

        public Car IncreaseNumberOfViews()
        {
            NumberOfViews++;
            return this;
        }

        public CarOverviewViewModel GenerateOverviewViewModel()
        {
            return new CarOverviewViewModel(Id, Maker, Model, KilometersTraveled,
                Pictures.Select(x => x.PictureUrl).ToArray(), Address);
        }

        public CarOutputViewModel GenerateCarOutputViewModel()
        {
            return new CarOutputViewModel()
            {
                Id = Id,
                Plate = Plate,
                Maker = Maker,
                Model = Model,
                MakeDate = MakeDate,
                MakedDate = MakedDate,
                KilometersTraveled = KilometersTraveled,
                Price = Price,
                AcceptsChange = AcceptsChange,
                IpvaIsPaid = IpvaIsPaid,
                IsLicensed = IsLicensed,
                IsArmored = IsArmored,
                Message = Message,
                TypeOfExchange = ConvertTypeOfExchangeToString(ExchangeType),
                GasolineType = ConvertGasolineTypeToString(GasolineType),
                Color = Color,
                Address = Address,
                NumberOfViews = NumberOfViews,
                Pictures = Pictures.Select(x => x.PictureUrl).ToArray()
            };
        }

        public void GenerateCarPictures(string[] pictures)
        {
            foreach (string pic in pictures)
            {
                CarPicture cp = new(Owner.UserName, Id, pic);
                Pictures.Add(cp);
            }
        }

        public async static Task<Car> GenerateWithInsertCarViewModel(InsertCarViewModel vm, User owner)
        {
            if (vm is null)
                throw new ArgumentNullException(nameof(vm), "View model must not be null");

            if (owner is null)
                throw new ArgumentNullException(nameof(owner), "Owner must not be null");

            return new Car
            {
                Owner = owner,
                Plate = vm.Plate,
                Maker = vm.Maker,
                Model = vm.Model,
                Price = vm.Price,
                MakeDate = vm.MakeDate,
                MakedDate = vm.MakedDate,
                KilometersTraveled = vm.KilometersTraveled,
                AcceptsChange = vm.AcceptsChange,
                IsArmored = vm.IsArmored,
                IsLicensed = vm.IsLicensed,
                IpvaIsPaid = vm.IpvaIsPaid,
                Message = vm.Message,
                Color = vm.Color,
                Address = await Address.BuildAddress(vm.ZipCode, vm.Location, vm.District, vm.Street),
                ExchangeType = ConvertStringToTypeOfExchange(vm.ExchangeType),
                GasolineType = ConvertStringToGasolineType(vm.GasolineType)
            };
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
