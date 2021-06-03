using ICar.Infrastructure.Models;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    public static class OutputGenerator
    {
        public static dynamic GenerateCityOutput(City city)
        {
            return new
            {
                city.Name
            };
        }

        public static dynamic[] GenerateCityOutput(List<City> cities)
        {
            dynamic[] output = new dynamic[cities.Count];

            for (int i = 0; i < cities.Count; i++)
            {
                output[i] = new
                {
                    cities[i].Name
                };
            }

            return output;
        }
    }
}
