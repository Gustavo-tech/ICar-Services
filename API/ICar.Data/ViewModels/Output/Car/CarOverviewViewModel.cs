using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output.Car
{
    public class CarOverviewViewModel
    {
        public string Id { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public double KilometersTraveled { get; private set; }
        public string[] Pictures { get; private set; }
        public Address Address { get; private set; }

        public CarOverviewViewModel(string id, string maker, string model, 
            double kilometersTraveled, string[] pictures, Address address)
        {
            Id = id;
            Maker = maker;
            Model = model;
            KilometersTraveled = kilometersTraveled;
            Pictures = pictures;
            Address = address;
        }
    }
}
