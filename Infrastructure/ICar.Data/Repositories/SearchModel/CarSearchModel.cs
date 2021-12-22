using Newtonsoft.Json;

namespace ICar.Infrastructure.Repositories.Search
{
    public class CarSearchModel
    {
        [JsonProperty("maker")]
        public string Maker { get; }

        [JsonProperty("model")]
        public string Model { get; }

        [JsonProperty("minPrice")]
        public int? MinPrice { get; }

        [JsonProperty("maxPrice")]
        public int? MaxPrice { get; }

        [JsonProperty("maxKilometers")]
        public int? MaxKilometers { get; }
    }
}
