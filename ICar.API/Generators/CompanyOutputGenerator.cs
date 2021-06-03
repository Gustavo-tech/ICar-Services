using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Generators
{
    public static class CompanyOutputGenerator
    {
        public static dynamic GenerateCompanyOutput(Company company)
        {
            List<DateTime> companyLoginTimes = GenerateCompanyLoginTimes(company);
            return new
            {
                CNPJ = company.Cnpj,
                company.Email,
                company.Name,
                Cities = GeneralOutputGenerator.GenerateCityOutput(company.Cities),
                CompanyLogins = GeneralOutputGenerator.GenerateLoginsOutput(companyLoginTimes)
            };
        }

        public static dynamic[] GenerateCompanyOutput(List<Company> companies)
        {
            dynamic[] output = new dynamic[companies.Count];

            for (int i = 0; i < companies.Count; i++)
            {
                List<DateTime> companyLoginTimes = GenerateCompanyLoginTimes(companies[i]);
                output[i] = new
                {
                    CNPJ = companies[i].Cnpj,
                    companies[i].Email,
                    companies[i].Name,
                    Cities = GeneralOutputGenerator.GenerateCityOutput(companies[i].Cities),
                    CompanyLogins = GeneralOutputGenerator.GenerateLoginsOutput(companyLoginTimes)
                };
            }

            return output;
        }

        private static List<DateTime> GenerateCompanyLoginTimes(Company company)
        {
            List<DateTime> companyLoginTimes = new();

            try
            {
                foreach (CompanyLogin login in company.CompanyLogins)
                {
                    companyLoginTimes.Add(login.Time);
                }

                return companyLoginTimes;
            }
            catch (Exception)
            {
                return companyLoginTimes;
            }
        }
    }
}
