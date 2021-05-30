using ICar.Data.Models.Entities.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICar.Data.Models.Entities.Logins
{
    public class CompanyLogin
    {
        public int Id { get; set; }
        public string CompanyCnpj { get; set; }
        public Company Company { get; set; }
        public DateTime Time { get; set; }

        public CompanyLogin()
        { }

        public CompanyLogin(int id, string companyCnpjFk, Company company, DateTime time)
        {
            Id = id;
            CompanyCnpj = companyCnpjFk;
            Company = company;
            Time = time;
        }
    }
}
