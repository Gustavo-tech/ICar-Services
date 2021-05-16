using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Companies;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Queries
{
    public class CompanyQueries : ICompanyQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        private List<City> GetCompanyCities(string cnpj)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * FROM cities WHERE Id IN (SELECT CityId FROM companies_cities WHERE CompanyCnpj = @Cnpj)";
                return connection.QueryAsync<City>(query, new { Cnpj = cnpj }).Result.ToList();
            }
        }


        public List<Company> GetCompanies(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"SELECT TOP {quantity} FROM companies";
                    return connection.Query<Company>(quantityQuery).ToList();
                }

                string selectQuery = "select * from companies";
                List<Company> companies = connection.QueryAsync<Company>(selectQuery).Result.ToList();

                foreach (Company company in companies)
                {
                    company.Cities = GetCompanyCities(company.Cnpj);
                }

                return companies;
            }

        }

        public Company GetCompanyByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                List<City> companyCities = GetCompanyCities(email);

                string query = "SELECT * FROM companies WHERE Email = @Email";
                Company company = connection.QueryAsync<Company>(query, new { Email = email }).Result.FirstOrDefault();

                company.Cities = companyCities;
                return company;
            }
        }

        public Company GetCompanyByCnpj(string cnpj)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                List<City> companyCities = GetCompanyCities(cnpj);
                string query = "SELECT * FROM companies WHERE cnpj = @Cnpj";
                Company company = connection.QueryAsync<Company>(query, new { Cnpj = cnpj }).Result.FirstOrDefault();
                company.Cities = companyCities;
                return company;
            }
        }

        public async Task InsertCompany(NewCompany company, bool isAdmin = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "EXECUTE sp_insert_company @Cnpj, @Name, @Email, @Password, @Role, @Cities";
                await connection.ExecuteAsync(query, new
                {
                    Cnpj = company.Cnpj,
                    Name = company.Name,
                    Email = company.Email,
                    Password = company.Password,
                    Role = isAdmin ? "admin" : "client",
                    Cities = company.Cities
                });
            }
        }
    }
}
