using Dapper;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries {
    public class UserQueries : IUserQueries {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();
        public List<User> GetUsers(int? quantity = null) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                if (quantity != null) {
                    string quantityQuery = $"select top {quantity} from users";
                    return connection.Query<User>(quantityQuery).ToList();
                }

                string selectQuery = "select * from users";
                return connection.Query<User>(selectQuery).ToList();
            }

        }

        public User GetUserByEmail(string email) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = $"execute sp_get_user '{email}'";
                return connection.Query<User>(query, new { Email = email }).FirstOrDefault();
            }
        }

        public User GetUserByCpf(string cpf) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = $"execute sp_get_user_by_cnpj @Cpf";
                return connection.Query<User>(query, new { Cpf = cpf }).FirstOrDefault();
            }
        }

        public void InsertUser(User user, bool isAdmin = false) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query;
                if (isAdmin) {
                    query = "execute sp_create_user @Cpf, @Name, @Email, @Password, 'admin', @City";
                    connection.Query(query, new {
                        Cpf = user.Cpf,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        Role = user.Role,
                        City = user.City
                    });
                }
                else {
                    query = "execute sp_create_user @Cpf, @Name, @Email, @Password, 'client', @City";
                    connection.Query(query, new {
                        Cpf = user.Cpf,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        Role = user.Role,
                        City = user.City
                    });
                }
            }
        }
    }
}
