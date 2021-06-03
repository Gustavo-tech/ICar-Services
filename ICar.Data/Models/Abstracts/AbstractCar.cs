using ICar.Infrastructure.Models.Entities;
using ICar.Infrastructure.Models.Enums.Car;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Infrastructure.Models.Abstracts
{
    public abstract class AbstractCar
    {
        [Key]
        public string Plate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int MakeDate { get; set; }
        public int MakedDate { get; set; }
        public double KilometersTraveled { get; set; }
        public double Price { get; set; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsArmored { get; set; }
        public string Message { get; set; }
        public TypeOfExchange TypeOfExchange { get; set; }
        public Color Color { get; set; }
        public GasolineType GasolineType { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<CarImage> CarImages { get; set; }
        public int NumberOfViews { get; set; }

        public AbstractCar()
        { }
    }
}
