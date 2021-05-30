namespace ICar.Data.Models.Entities
{
    public class City
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public City()
        { }

        public City(string name)
        {
            Name = name;
        }
    }
}
