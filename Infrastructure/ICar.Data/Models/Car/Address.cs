using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Models
{
    public class Address : Entity
    {
        [JsonProperty("cep")]
        public string ZipCode { get; private set; }

        [JsonProperty("localidade")]
        public string Location { get; private set; }

        [JsonProperty("bairro")]
        public string District { get; private set; }

        [JsonProperty("logradouro")]
        public string Street { get; private set; }

        private Address()
        {

        }

        private Address(string zipCode, string location, string district, string street)
            : base()
        {
            ZipCode = zipCode;
            Location = location;
            District = district;
            Street = street;
        }

        public static async Task<Address> BuildAddress(string zipCode, string location, string district, string street)
        {
            await Validate(zipCode, location, district, street);

            Address address = new(zipCode, location, district, street);
            return address;
        }

        private static async Task Validate(string zipCode, string location, string district, string street)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("Zip code is empty", nameof(zipCode));

            else if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("Location is empty", nameof(location));

            else if (string.IsNullOrWhiteSpace(district))
                throw new ArgumentException("District is empty", nameof(district));

            else if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is empty", nameof(street));

            HttpClient client = new();

            HttpResponseMessage respone = await client.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");
            respone.EnsureSuccessStatusCode();

            string json = await respone.Content.ReadAsStringAsync();
            Address address = JsonConvert.DeserializeObject<Address>(json);

            if (!string.Equals(address.Location, location, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Location is different from API");

            else if (!string.Equals(address.District, district, StringComparison.OrdinalIgnoreCase))
                throw new Exception("District is different from API");

            else if (!string.Equals(address.Street, street, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Street is different from API");
        }
    }
}
