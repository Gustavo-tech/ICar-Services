using Dapper;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();
        public List<User> GetUsers(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"SELECT TOP {quantity} FROM Users";
                    return connection.Query<User>(quantityQuery).ToList();
                }

                string selectQuery = "SELECT * FROM Users";
                return connection.Query<User>(selectQuery).ToList();
            }

        }

        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"EXECUTE spGetUser '{email}'";
                return connection.Query<User>(query, new { Email = email }).FirstOrDefault();
            }
        }
    }
}
