//using ICar.Data.Models.Entities;
//using ICar.Data.Models.Entities.Accounts;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ICar.Data
//{
//    public class DataInjector
//    {
//        private readonly DatabaseContext _dbContext;

//        public DataInjector(DatabaseContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        private async Task InsertInitialCompaniesAsync()
//        {
//            try
//            {
//                if (await _dbContext.Companies.AnyAsync() == false)
//                    List<Company> companiesToInser = new List<Company>
//                {
//                    new Company("06.990.590/0001-23", "Google", "google@gmail.com", "Google&", 0, DateTime.Now, "client"),
//                    new Company("60.316.817/0001-03", "Microsoft", "microsoft@gmail.com", "Microsoft&", 0, DateTime.Now, "client"),
//                };
//                string query = "INSERT INTO companies VALUES ('06.990.590/0001-23', 'Google', 'google@gmail.com', 'Google&', 0, GETDATE(), 'client'), " +
//                                "('60.316.817/0001-03', 'Microsoft', 'microsoft@gmail.com', 'Mirosoft&', 0, GETDATE(), 'client'), " +
//                                "('01.192.333/0001-22', 'Honda', 'honda@gmail.com', 'Honda&', 0, GETDATE(), 'admin')";

//            }
//            catch (Exception)
//            {
//                return;
//            }
//        }

//        private async Task InsertInitialNewsAsync()
//        {
//            if (!TableHasData("news"))
//            {
//                using (SqlConnection connection = new SqlConnection(_dbConnection))
//                {
//                    try
//                    {
//                        string query = "INSERT INTO news VALUES ('Initial', 'initial', GETDATE(), '897.907.267-98', null)," +
//                                       "('Second', 'Second', GETDATE(), null, '01.192.333/0001-22')";
//                        connection.Execute(query);
//                    }
//                    catch (Exception)
//                    {
//                        return;
//                    }
//                }
//            }
//        }

//        private async Task InsertInitialCitiesAsync()
//        {
//            if (await _dbContext.Cities.AnyAsync() == false)
//            {
//                try
//                {
//                    List<City> cities = new List<City> 
//                    {
//                        new City("Vancouver"),
//                        new City("Valinhos"),
//                        new City("Campinas"),
//                        new City("Vinhedo"),
//                        new City("Toronto"),
//                    };

//                    await _dbContext.Cities.AddRangeAsync(cities);
//                    await _dbContext.SaveChangesAsync();
//                }
//                catch (Exception)
//                {
//                    return;
//                }
//            }
//        }

//        private async Task InsertInitialUsersAsync()
//        {
//            if (!TableHasData("users"))
//            {
//                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
//                {
//                    try
//                    {
//                        string query = "INSERT INTO users VALUES" +
//                                        "('897.907.267-98', 'Gustavo', 'gustavo@gmail.com', 'gustavo&', 0, GETDATE(), 'admin', 1), " +
//                                        "('832.217.220-12', 'Andre', 'andre@gmail.com', 'andre&', 0, GETDATE(), 'client', 2), " +
//                                        "('187.201.451-11', 'Mayara', 'mayara@gmail.com', 'mayara&', 0, GETDATE(), 'client', 3), " +
//                                        "('200.664.843-07', 'Lucas', 'lucas@gmail.com', 'lucas&', 0, GETDATE(), 'client', 4), " +
//                                        "('312.844.729-17', 'Mariana', 'mariana@gmail.com', 'mariana&', 0, GETDATE(), 'client', 5)";

//                        sqlConnection.Execute(query);
//                    }
//                    catch (Exception)
//                    {
//                        return;
//                    }
//                }
//            }
//        }

//        private async Task InsertInitialCompaniesCitiesAsync()
//        {
//            if (!TableHasData("companies_cities"))
//            {
//                using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
//                {
//                    try
//                    {
//                        string query = "INSERT INTO companies_cities VALUES " +
//                                        "('01.192.333/0001-22', 1), ('01.192.333/0001-22', 2), ('01.192.333/0001-22', 3), ('01.192.333/0001-22', 4), " +
//                                        "('60.316.817/0001-03', 1), ('60.316.817/0001-03', 2), ('60.316.817/0001-03', 3), " +
//                                        "('06.990.590/0001-23', 1), ('06.990.590/0001-23', 2)";

//                        sqlConnection.Execute(query);
//                    }
//                    catch (Exception)
//                    {
//                        return;
//                    }
//                }
//            }
//        }

//        private async Task InsertInitialCarsAsync()
//        {
//            if (!TableHasData("cars"))
//            {
//                using (SqlConnection connection = new SqlConnection(_dbConnection))
//                {
//                    try
//                    {
//                        string query = "INSERT INTO cars VALUES " +
//                                                   "('PGX-9090', 'Honda', 'Civic', 2019, 2019, 21000, 'man', 109000, 'Black', 0, 1, 1, 'Gas', 0, '', 1, '897.907.267-98', NULL, 0), " +
//                                                   "('XLP-8090', 'Peugeot', '206', 2017, 2018, 90000, 'aut', 42000, 'White', 0, 1, 1, 'Die', 0, '', 1, '187.201.451-11', NULL, 0)"; ;
//                        connection.Execute(query);
//                    }
//                    catch (Exception)
//                    {
//                        return;
//                    }
//                }

//            }
//        }

//        public async Task InsertInitialDataAsync()
//        {
//            await InsertInitialCitiesAsync();
//            await InsertInitialUsersAsync();
//            await InsertInitialCompaniesAsync();
//            await InsertInitialCompaniesCitiesAsync();
//            await InsertInitialNews();
//            await InsertInitialCars();
//        }
//    }
//}
