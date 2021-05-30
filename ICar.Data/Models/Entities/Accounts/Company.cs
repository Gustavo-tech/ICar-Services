using ICar.Data.Models.Abstracts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICar.Data.Models.Entities.Accounts
{
    public class Company : Entity
    {
        public string Cnpj { get; set; }
        public List<CompanyCar> CompanyCars { get; set; }
        public List<CompanyCity> Cities { get; set; }
        public List<CompanyLogin> CompanyLogins { get; set; }
        public List<CompanyNews> CompanyNews { get; set; }

        public Company()
        { }
    }
}
