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
                return connection.Query<Company>(selectQuery).ToList();
            }
            
        }

        public Company GetCompanyByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * FROM Companies WHERE Email = @Email";
                return connection.Query<Company>(query, new { Email = email }).FirstOrDefault();
            }
        }
    }
}
