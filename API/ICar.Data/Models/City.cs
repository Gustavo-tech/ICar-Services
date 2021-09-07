using System;

namespace ICar.Infrastructure.Models
{
    public class City
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public City()
        { }

        public City(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Can't create a city with empty name");

            Name = name;
        }
    }
}
