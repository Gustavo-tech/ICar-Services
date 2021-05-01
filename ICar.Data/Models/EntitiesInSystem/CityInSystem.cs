namespace ICar.Data.Models.EntitiesInSystem
{
    public class CityInSystem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CityInSystem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
