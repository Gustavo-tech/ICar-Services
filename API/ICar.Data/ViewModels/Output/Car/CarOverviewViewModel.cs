using ICar.Infrastructure.Models;

namespace ICar.Infrastructure.ViewModels.Output.Car
{
    public class CarOverviewViewModel
    {
        public string Id { get; private set; }
        public string Maker { get; private set; }
        public string Model { get; private set; }
        public int MakeDate { get; private set; }
        public int MakedDate { get; private set; }
        public int Price { get; private set; }
        public int NumberOfViews { get; private set; }
        public double KilometersTraveled { get; private set; }
        public string[] Pictures { get; private set; }
        public Address Address { get; private set; }

        public CarOverviewViewModel(string id, string maker, string model, 
            int makeDate, int makedDate, int price, int numberOfViews, 
            double kilometersTraveled, string[] pictures, Address address)
        {
            Id = id;
            Maker = maker;
            Model = model;
            MakeDate = makeDate;
            MakedDate = makedDate;
            Price = price;
            NumberOfViews = numberOfViews;
            KilometersTraveled = kilometersTraveled;
            Pictures = pictures;
            Address = address;
        }
    }
}
