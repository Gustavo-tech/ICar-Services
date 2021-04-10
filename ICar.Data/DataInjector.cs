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
            if (!TableHasData("Companies"))
            {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
                {
                    try
                    {
                        string query = "INSERT INTO Companies VALUES ('06.990.590/0001-23', 'Google', 'google@gmail.com', 'Google&', 0, GETDATE(), 'client'), " +
                                        "('60.316.817/0001-03', 'Microsoft', 'microsoft@gmail.com', 'Mirosoft&', 0, GETDATE(), 'client'), " +
                                        "('01.192.333/0001-22', 'Honda', 'honda@gmail.com', 'Honda&', 0, GETDATE(), 'admin')";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
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

        private static void InsertInitialCompaniesCities()
        {
            if (TableHasData("Companies") && !TableHasData("CompaniesCities"))
            {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
                {
                    try
                    {
                        string query = "INSERT INTO CompaniesCities VALUES " +
                                        "(1, 1), (1, 2), (1, 3), (1, 4)" +
                                        "(2, 1), (2, 2), (2, 3), " +
                                        "(3, 1), (3, 2)";

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
            InsertInitialCompaniesCities();
        }
    }
}
