using Dapper;
using System;
using System.Data.SqlClient;

namespace ICar.Data {
    public static class DataInjector {
        private static readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        private static bool TableHasData(string tableName) {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                string query = $"select * from {tableName}";
                return sqlConnection.Execute(query) > 0;
            }
        }

        private static void InsertInitialCompanies() {
            if (!TableHasData("companies")) {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                    try {
                        string query = "insert into companies values ('06.990.590/0001-23', 'Google', 'google@gmail.com', 'Google&', 0, GETDATE(), 'client'), " +
                                        "('60.316.817/0001-03', 'Microsoft', 'microsoft@gmail.com', 'Mirosoft&', 0, GETDATE(), 'client'), " +
                                        "('01.192.333/0001-22', 'Honda', 'honda@gmail.com', 'Honda&', 0, GETDATE(), 'admin')";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception) {
                        return;
                    }
                }
            }
        }

        private static void InsertInitialNews() {
            if (!TableHasData("news")) {
                using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                    try {
                        string query = "insert into news values ('Initial', 'initial', GETDATE(), '897.907.267-98', null)," +
                                       "('Second', 'Second', GETDATE(), null, '01.192.333/0001-22')";
                        connection.Execute(query);
                    }
                    catch (Exception) {
                        return;
                    }
                }
            }
        }

        private static void InsertInitialCities() {
            if (!TableHasData("cities")) {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                    try {
                        string query = "insert into cities values ('Vancouver'), ('Campinas'), ('Sorocaba'), ('Santos'), " +
                                        "('Valinhos'), ('Vinhedo'), ('Toronto')";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception) {
                        return;
                    }
                }
            }
        }

        private static void InsertInitialUsers() {
            if (!TableHasData("users")) {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                    try {
                        string query = "insert into users values " +
                                        "('897.907.267-98', 'Gustavo', 'gustavo@gmail.com', 'gustavo&', 0, GETDATE(), 'admin', 1), " +
                                        "('832.217.220-12', 'Andre', 'andre@gmail.com', 'andre&', 0, GETDATE(), 'client', 2), " +
                                        "('187.201.451-11', 'Mayara', 'mayara@gmail.com', 'mayara&', 0, GETDATE(), 'client', 3), " +
                                        "('200.664.843-07', 'Lucas', 'lucas@gmail.com', 'lucas&', 0, GETDATE(), 'client', 4), " +
                                        "('312.844.729-17', 'Mariana', 'mariana@gmail.com', 'mariana&', 0, GETDATE(), 'client', 5)";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception) {
                        return;
                    }
                }
            }
        }

        private static void InsertInitialCompaniesCities() {
            if (!TableHasData("companies_cities")) {
                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                    try {
                        string query = "inserto into companies_cities values " +
                                        "('01.192.333/0001-22', 1), ('01.192.333/0001-22', 2), ('01.192.333/0001-22', 3), ('01.192.333/0001-22', 4), " +
                                        "('60.316.817/0001-03', 1), ('60.316.817/0001-03', 2), ('60.316.817/0001-03', 3), " +
                                        "('06.990.590/0001-23', 1), ('06.990.590/0001-23', 2)";

                        sqlConnection.Execute(query);
                    }
                    catch (Exception) {
                        return;
                    }
                }
            }
        }

        public static void InsertInitialData() {
            InsertInitialCities();
            InsertInitialUsers();
            InsertInitialCompanies();
            InsertInitialCompaniesCities();
            InsertInitialNews();
        }
    }
}
