using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Infrastructure.Models.Entities
{
    public sealed class CompanyCity
    {
        public string CompanyCnpj { get; set; }
        public Company Company { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public CompanyCity()
        { }
    }
}
