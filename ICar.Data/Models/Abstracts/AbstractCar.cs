using ICar.Data.Models.Entities;
using ICar.Data.Models.Enums.Car;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Abstracts
{
    public abstract class AbstractCar
    {
        [Key]
        public string Plate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "A maker should't have more than 30 chars")]
        public string Maker { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(30, ErrorMessage = "A model should't have more than 30 chars")]
        public string Model { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int MakeDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int MakedDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0, 1000000, ErrorMessage = "A car can't have more than 1000000 {0}")]
        public double KilometersTraveled { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0.0, 10000000, ErrorMessage = "A car price should be between 0 and 10000000")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public bool AcceptsChange { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public bool IpvaIsPaid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public bool IsLicensed { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public bool IsArmored { get; set; }

        [MaxLength(400, ErrorMessage = "A message can't have more than 400 chars")]
        public string Message { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public TypeOfExchange TypeOfExchange { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public Color Color { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public GasolineType GasolineType { get; set; }

        [ForeignKey("CityId")]
        [Required(ErrorMessage = "{0} is required")]
        public City City { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CarPlate")]
        public List<CarImage> CarImages { get; set; }

        public int NumberOfViews { get; set; }
    }
}
