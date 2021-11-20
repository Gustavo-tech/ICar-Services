using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output.Car
{
    public class CarOverviewViewModel
    {
        public int? Id { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public double KilometersTraveled { get; private set; }
        public string[] Pictures { get; private set; }
        public string City { get; private set; }

        public CarOverviewViewModel(int? id, string maker, string model, 
            double kilometersTraveled, string[] pictures, string city)
        {
            Id = id;
            Maker = maker;
            Model = model;
            KilometersTraveled = kilometersTraveled;
            Pictures = pictures;
            City = city;
        }
    }
}
