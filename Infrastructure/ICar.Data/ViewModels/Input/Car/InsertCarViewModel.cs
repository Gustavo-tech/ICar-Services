namespace ICar.Infrastructure.ViewModels.Input.Car
{
    public class InsertCarViewModel
    {
        public string Plate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int MakeDate { get; set; }
        public int MakedDate { get; set; }
        public int KilometersTraveled { get; set; }
        public int Price { get; set; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsArmored { get; set; }
        public string Message { get; set; }
        public string ExchangeType { get; set; }
        public string Color { get; set; }
        public string GasolineType { get; set; }
        public string[] Pictures { get; set; }
        public AddressInfo Address { get; set; }
        public ContactInfo Contact { get; set; }
    }

    public class ContactInfo
    {
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Nickname { get; set; }

        public ContactInfo(string phoneNumber, string emailAddress, string nickname)
        {
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Nickname = nickname;
        }
    }

    public class AddressInfo
    {
        public string ZipCode { get; private set; }
        public string Location { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }

        public AddressInfo(string zipCode, string location, string district, string street)
        {
            ZipCode = zipCode;
            Location = location;
            District = district;
            Street = street;
        }
    }
}
