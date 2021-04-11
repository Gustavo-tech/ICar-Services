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
                string query = $"execute sp_get_company_cities '{email}'";
                return connection.Query<string>(query).ToList();
            }
        }

        public List<Company> GetCompanies(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"select top {quantity} from Companies";
                    return connection.Query<Company>(quantityQuery).ToList();
                }

                string selectQuery = "select * from Companies";
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

                string query = "select * from Companies where Email = @Email";
                Company company = connection.Query<Company>(query, new { Email = email }).FirstOrDefault();

                company.Cities = companyCities;
                return company;
            }
        }

        public void InsertCompany(Company company, bool isAdmin)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (GetCompanyByEmail(company.Email) == null)
                {
                    string query = "EXECUTE sp_insert_company '@Cnpj', '@Name', '@Email', '@Password', '@Role', '@Cities'";
                    connection.Query(query, new
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
}
