using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();
        public List<UserInSystem> GetUsers(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"select top {quantity} from users";
                    return connection.Query<UserInSystem>(quantityQuery).ToList();
                }

                string selectQuery = "select * from users";
                return connection.Query<UserInSystem>(selectQuery).ToList();
            }

        }

        public UserInSystem GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"execute sp_get_user '{email}'";
                return connection.Query<UserInSystem>(query, new { Email = email }).FirstOrDefault();
            }
        }

        public UserInSystem GetUserByCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"execute sp_get_user_by_cnpj @Cpf";
                return connection.Query<UserInSystem>(query, new { Cpf = cpf }).FirstOrDefault();
            }
        }

        public void InsertUser(User newUser, bool isAdmin = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query;
                if (isAdmin)
                {
                    query = "execute sp_create_user @Cpf, @Name, @Email, @Password, 'admin', @City";
                    connection.Query(query, new
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
                    query = "execute sp_create_user @Cpf, @Name, @Email, @Password, 'client', @City";
                    connection.Query(query, new
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
