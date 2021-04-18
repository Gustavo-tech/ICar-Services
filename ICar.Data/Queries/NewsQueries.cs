using Dapper;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries {
    public class NewsQueries : INewsQueries {
        private string _dbConnectionString = DatabaseConnectionFactory.GetICarConnection();

        public List<News> GetNews(int? quantity = null) {
            using(SqlConnection connection = new SqlConnection(_dbConnectionString)) {
                string query;
                if (quantity == null)
                    query = "select * from news";

                else
                    query = $"select top {quantity.Value} from news";

                return connection.Query<News>(query).ToList();
            }
        }

        public void InsertNews(News news, bool userIsCompany = false) {
            using(SqlConnection connection = new SqlConnection(_dbConnectionString)) {
                string query;
                if (userIsCompany) {
                    query = "insert into news values (@Title, @Text, GETDATE(), 'null', @Cnpj)";
                    connection.Execute(query, new { Title = news.Title, Text = news.Text, Cnpj = news.Company.Cnpj });
                }

                else
                    query = "insert into news values (@Title, @Text, GETDATE(), @Cpf, 'null')";
                    connection.Execute(query, new { Title = news.Title, Text = news.Text, Cpf = news.User.Cpf });
            }
        }
    }
}
