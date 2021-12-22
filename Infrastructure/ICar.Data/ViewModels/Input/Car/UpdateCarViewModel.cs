namespace ICar.Infrastructure.ViewModels.Input.Car
{
    public class UpdateCarViewModel
    {
        public string Id { get; set; }
        public string OwnerEmail { get; set; }
        public int KilometersTraveled { get; set; }
        public int Price { get; set; }
        public string Message { get; set; }
        public bool AcceptsChange { get; set; }
        public bool IpvaIsPaid { get; set; }
        public bool IsLicensed { get; set; }
        public bool IsArmored { get; set; }
        public string ZipCode { get; set; }
        public string Location { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string[] Pictures { get; set; }
    }
}
