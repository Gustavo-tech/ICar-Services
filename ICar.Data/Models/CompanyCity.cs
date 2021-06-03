﻿namespace ICar.Infrastructure.Models
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