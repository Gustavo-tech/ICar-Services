using Dapper;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Data.Queries {
    public class CarQuery : ICarQuery {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        public List<Car> GetAllCars() {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "select * from cars";
                return connection.Query<Car>(query).ToList();
            }
        }

        public Car GetCar(string plate) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "select * from cars where plate = @Plate";
                return connection.Query<Car>(query, new { Plate = plate }).FirstOrDefault();
            }
        }

        public List<Car> GetCarsWithCnpj(string cnpj) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "select * from cars where company_cnpj = @Cnpj";
                return connection.Query<Car>(query, new { Cnpj = cnpj }).ToList();
            }
        }

        public List<Car> GetCarsWithCpf(string cpf) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "select * from cars where user_cpf = @Cpf";
                return connection.Query<Car>(query, new { Cpf = cpf }).ToList();
            }
        }

        public void InsertCar(Car car) {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car) {
            throw new NotImplementedException();
        }

        public void IncreaseNumberOfViews(string carPlate) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string selectNumberOfViews = "select number_of_views from cars where plate = @Plate";
                int currentViews = connection.ExecuteScalar<int>(selectNumberOfViews, new { Plate = carPlate });

                string query = "update cars set number_of_views = @NumberOfViews";
                connection.Execute(query, new { NumberOfViews = selectNumberOfViews + 1 });
            }
        }

        public void DeleteCar(int id) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "delete from cars where id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
