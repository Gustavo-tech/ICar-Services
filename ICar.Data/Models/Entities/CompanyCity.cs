using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities
{
    public class CompanyCity
    {
        public string CompanyCnpjFk { get; set; }

        [ForeignKey("Id")]
        public City City { get; set; }

        public CompanyCity()
        { }

        public CompanyCity(string companyCnpj, City city)
        {
            CompanyCnpjFk = companyCnpj;
            City = city;
        }
    }
}
