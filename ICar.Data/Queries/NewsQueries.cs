using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.News;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class NewsQueries : INewsQueries
    {
        private string _dbConnectionString = DatabaseConnectionFactory.GetICarConnection();

        public List<NewsInSystem> GetNews(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query;
                if (quantity == null)
                    query = "select * from news";

                else
                    query = $"select top {quantity.Value} from news";

                return connection.Query<NewsInSystem>(query).ToList();
            }
        }

        public void InsertNews(News newNews, bool userIsCompany = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query;
                if (userIsCompany)
                {
                    query = "insert into news values (@Title, @Text, GETDATE(), null, @Cnpj)";
                    connection.Execute(query, new { Title = newNews.Title, Text = newNews.Text, Cnpj = newNews.Cnpj });
                }

                else
                    query = "insert into news values (@Title, @Text, GETDATE(), @Cpf, null)";
                connection.Execute(query, new { Title = newNews.Title, Text = newNews.Text, Cpf = newNews.Cpf });
            }
        }

        public void UpdateNews(int id, UpdatedNews newsUpdated)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query = "update news set title = @Title, text = @Text, last_update = GETDATE() where id = @Id";
                connection.Execute(query, new
                {
                    Id = id,
                    Title = newsUpdated.Title,
                    Text = newsUpdated.Text
                });
            }
        }

        public void DeleteNews(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnectionString))
            {
                string query = "delete from news where id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
