using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
                    string quantityQuery = $"SELECT TOP {quantity} FROM users";
                    return connection.Query<User>(quantityQuery).ToList();
                }

                string selectQuery = "SELECT * FROM Users";
                return connection.QueryAsync<User>(selectQuery).Result.ToList();
            }

        }

        public User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"EXECUTE sp_get_user '{email}'";
                return connection.QueryAsync<User>(query, new { Email = email }).Result.FirstOrDefault();
            }
        }

        public User GetUserByCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "DECLARE @city_id INT; \n" +
                "SET @city_id = (SELECT CityId FROM users WHERE Cpf = @Cpf)\n" +
	
	            "SELECT\n" +
                    "Cpf, " +
                    "u.name, " +
		            "Email, " +
		            "Password, " +
		            "NumberOfCarsSelling, " +
		            "AccountCreationDate, " +
		            "Role, " +
		            "c.Name as City\n" +
                "FROM\n" +
                    "users u\n" +
                "INNER JOIN cities c ON u.CityId = c.Id\n" +
                "WHERE u.Cpf = @Cpf";
                return connection.QueryAsync<User>(query, new { Cpf = cpf }).Result.FirstOrDefault();
            }
        }

        public async Task InsertUser(User newUser, bool isAdmin = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query;
                if (isAdmin)
                {
                    query = "EXECUTE sp_create_user @Cpf, @Name, @Email, @Password, 'admin', @City";
                    await connection.ExecuteAsync(query, new
                    {
                        Cpf = newUser.Cpf,
                        Name = newUser.Name,
                        Email = newUser.Email,
                        Password = newUser.Password,
                        Role = isAdmin ? "admin" : "client",
                        City = newUser.City
                    });
                }
                else
                {
                    query = "EXECUTE sp_create_user @Cpf, @Name, @Email, @Password, 'client', @City";
                    await connection.ExecuteAsync(query, new
                    {
                        Cpf = newUser.Cpf,
                        Name = newUser.Name,
                        Email = newUser.Email,
                        Password = newUser.Password,
                        Role = isAdmin ? "admin" : "client",
                        City = newUser.City
                    });
                }
            }
        }
    }
}
