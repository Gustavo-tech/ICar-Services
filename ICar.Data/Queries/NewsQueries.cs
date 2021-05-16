using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.News;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Queries
{
    public class NewsQueries : INewsQueries
    {
        private string _dbConnectionString = DatabaseConnectionFactory.GetICarConnection();

        public List<News> GetNews(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query;
                if (quantity == null)
                    query = "SELECT * FROM news";

                else
                    query = $"SELECT TOP {quantity.Value} FROM news";

                return connection.QueryAsync<News>(query).Result.ToList();
            }
        }

        public async Task InsertNews(NewNews newNews, bool userIsCompany = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query;
                if (userIsCompany)
                {
                    query = "INSERT INTO news VALUES (@Title, @Text, GETDATE(), NULL, @Cnpj)";
                    await connection.ExecuteAsync(query, new { Title = newNews.Title, Text = newNews.Text, Cnpj = newNews.Cnpj });
                }

                else
                {
                    query = "INSERT INTO news VALUES (@Title, @Text, GETDATE(), @Cpf, null)";
                    await connection.ExecuteAsync(query, new { Title = newNews.Title, Text = newNews.Text, Cpf = newNews.Cpf });
                }
            }
        }

        public async Task UpdateNews(int id, UpdatedNews newsUpdated)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query = "UPDATE news SET title = @Title, text = @Text, last_update = GETDATE() WHERE Id = @Id";
                await connection.ExecuteAsync(query, new
                {
                    Id = id,
                    Title = newsUpdated.Title,
                    Text = newsUpdated.Text
                });
            }
        }

        public async Task DeleteNews(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query = "DELETE FROM news WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
