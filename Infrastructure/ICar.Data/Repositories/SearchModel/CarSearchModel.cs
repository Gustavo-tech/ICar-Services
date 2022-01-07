using Newtonsoft.Json;

namespace ICar.Infrastructure.Repositories.Search
{
    public class CarSearchModel
    {
        [JsonProperty("maker")]
        public string Maker { get; private set; }

        [JsonProperty("model")]
        public string Model { get; private set; }

        [JsonProperty("minPrice")]
        public int? MinPrice { get; private set; }

        [JsonProperty("maxPrice")]
        public int? MaxPrice { get; private set; }

        [JsonProperty("maxKilometers")]
        public int? MaxKilometers { get; private set; }

        public CarSearchModel(string maker, string model, int? minPrice, int? maxPrice, int? maxKilometers)
        {
            Maker = maker;
            Model = model;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            MaxKilometers = maxKilometers;
        }
    }
}
