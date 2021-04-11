using Dapper;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class CompanyQueries : ICompanyQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        private List<string> GetComapanyCities(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"EXECUTE spGetCompanyCities '{email}'";
                return connection.Query<string>(query).ToList();
            }
        }

        public List<Company> GetCompanies(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"SELECT TOP {quantity} FROM Companies";
                    return connection.Query<Company>(quantityQuery).ToList();
                }

                string selectQuery = "SELECT * FROM Companies";
                List<Company> companies = connection.Query<Company>(selectQuery).ToList();

                foreach (Company company in companies)
                {
                    company.Cities = GetComapanyCities(company.Email);
                }

                return companies;
            }
            
        }

        public Company GetCompanyByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                List<string> companyCities = GetComapanyCities(email);

                string query = "SELECT * FROM Companies WHERE Email = @Email";
                Company company = connection.Query<Company>(query, new { Email = email }).FirstOrDefault();

                company.Cities = companyCities;
                return company;
            }
        }
    }
}
