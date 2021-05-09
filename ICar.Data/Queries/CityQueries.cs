﻿using Dapper;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class CityQueries : ICityQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();
        public CityInSystem GetCityById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * FROM cities WHERE Id = @Id";
                return connection.Query<CityInSystem>(query, new { Id = id }).FirstOrDefault();
            }
        }
    }
}
