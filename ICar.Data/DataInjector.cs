using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data
{
    public static class DataInjector
    {
        private static readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        private static bool TableHasData(string tableName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
            {
                string query = $"SELECT * FROM {tableName}";
                return sqlConnection.Execute(query) > 0;
            }
        }

        private static void InsertInitialCompanies()
        {

        }

        private static void InsertInitialCities()
        {
            if (!TableHasData("Cities"))
            {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
                {
                    try
                    {
                        string query = "INSERT INTO Cities VALUES ('Vancouver'), ('Campinas'), ('Sorocaba'), ('Santos'), " +
                                        "('Valinhos'), ('Vinhedo'), ('Toronto')";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        private static void InsertInitialUsers()
        {
            if (!TableHasData("Users"))
            {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
                {
                    try
                    {
                        string query = "INSERT INTO Users VALUES " +
                                        "('897.907.267-98', 'Gustavo', 'gustavo@gmail.com', 'gustavo&', 0, GETDATE(), 'admin', 1), " +
                                        "('832.217.220-12', 'Andre', 'andre@gmail.com', 'andre&', 0, GETDATE(), 'client', 2), " +
                                        "('187.201.451-11', 'Mayara', 'mayara@gmail.com', 'mayara&', 0, GETDATE(), 'client', 3), " +
                                        "('200.664.843-07', 'Lucas', 'lucas@gmail.com', 'lucas&', 0, GETDATE(), 'client', 4), " +
                                        "('312.844.729-17', 'Mariana', 'mariana@gmail.com', 'mariana&', 0, GETDATE(), 'client', 5)";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        public static void InsertInitialData()
        {
            InsertInitialCities();
            InsertInitialUsers();
            InsertInitialCompanies();
        }
    }
}
