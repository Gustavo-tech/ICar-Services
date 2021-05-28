using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities
{
    public class CompanyCity
    {
        public string CompanyCnpj { get; set; }

        [ForeignKey("Id")]
        public City City { get; set; }

        public CompanyCity()
        { }

        public CompanyCity(string companyCnpj, City city)
        {
            CompanyCnpj = companyCnpj;
            City = city;
        }
    }
}
