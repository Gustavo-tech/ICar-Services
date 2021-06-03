using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace ICar.API.Generators
{
    public static class GeneralOutputGenerator
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

        public static dynamic[] GenerateLoginsOutput(List<DateTime> dateTimes)
        {
            dynamic[] output = new dynamic[dateTimes.Count];


            for (int i = 0; i < dateTimes.Count; i++)
            {
                output[i] = new
                {
                    Time = dateTimes[i]
                };
            }

            return output;
        }
    }
}
