using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICar.Infrastructure.ViewModels.Input.Car
{
    public class InsertCarViewModel
    {
        [RegularExpression("[A-Z]{3}[-][0-9]{4}")]
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
        public string UserEmail { get; set; }
        public string City { get; set; }
        public List<string> Pictures { get; set; }
    }
}
