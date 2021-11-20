using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output.Car
{
    public class CarOutputViewModel
    {
        public string Id { get; internal set; }
        public string Plate { get; internal set; }
        public string Maker { get; internal set; }
        public string Model { get; internal set; }
        public int MakeDate { get; internal set; }
        public int MakedDate { get; internal set; }
        public int KilometersTraveled { get; internal set; }
        public int Price { get; internal set; }
        public bool AcceptsChange { get; internal set; }
        public bool IpvaIsPaid { get; internal set; }
        public bool IsLicensed { get; internal set; }
        public bool IsArmored { get; internal set; }
        public string Message { get; internal set; }
        public string TypeOfExchange { get; internal set; }
        public string Color { get; internal set; }
        public string GasolineType { get; internal set; }
        public int NumberOfViews { get; internal set; }
        public string[] Pictures { get; internal set; }

        public Address Address { get; internal set; }

        internal CarOutputViewModel()
        {

        }
    }
}
