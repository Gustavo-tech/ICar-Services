namespace ICar.Infrastructure.Models
{
    public class Address : Entity
    {
        public string ZipCode { get; private set; }
        public string Location { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }

        public Address(string zipCode, string location, string district, string street)
            : base()
        {
            ZipCode = zipCode;
            Location = location;
            District = district;
            Street = street;
        }
    }
}
