using Dapper;
using ICar.Data.Converter;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "execute sp_insert_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " + 
                    "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                    "@Message, @CityId, @UserCpf, @CompanyCnpj";
                connection.Execute(query, new {
                    Plate = car.Plate,
                    Maker = car.Maker,
                    Model = car.Model,
                    MakeYear = car.MakeDate,
                    MakedYear = car.MakedDate,
                    Kilometers = car.KilometersTraveled,
                    TypeOfExchange = car.TypeOfExchange,
                    Price = car.Price,
                    Color = car.Color,
                    AcceptsChange = CarPropertyConverter.ConvertBoolToBit(car.AcceptsChange),
                    IpvaIsPaid = CarPropertyConverter.ConvertBoolToBit(car.IpvaIsPaid),
                    IsLicensed = CarPropertyConverter.ConvertBoolToBit(car.IsLicensed),
                    GasolineType = car.GasolineType,
                    IsArmored = CarPropertyConverter.ConvertBoolToBit(car.IsArmored),
                    Message = car.Message,
                    CityId = car.CityId,
                    UserCpf = car.User.Cpf,
                    CompanyCnpj = car.Company.Cnpj,
                });
            }
        }

        public void UpdateCar(Car car) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string query = "execute sp_update_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                    "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                    "@Message, @CityId, @UserCpf, @CompanyCnpj";
                connection.Execute(query, new {
                    Plate = car.Plate,
                    Maker = car.Maker,
                    Model = car.Model,
                    MakeYear = car.MakeDate,
                    MakedYear = car.MakedDate,
                    Kilometers = car.KilometersTraveled,
                    TypeOfExchange = car.TypeOfExchange,
                    Price = car.Price,
                    Color = car.Color,
                    AcceptsChange = CarPropertyConverter.ConvertBoolToBit(car.AcceptsChange),
                    IpvaIsPaid = CarPropertyConverter.ConvertBoolToBit(car.IpvaIsPaid),
                    IsLicensed = CarPropertyConverter.ConvertBoolToBit(car.IsLicensed),
                    GasolineType = car.GasolineType,
                    IsArmored = CarPropertyConverter.ConvertBoolToBit(car.IsArmored),
                    Message = car.Message,
                    CityId = car.CityId,
                    UserCpf = car.User.Cpf,
                    CompanyCnpj = car.Company.Cnpj,
                });
            }
        }

        public void UpdatePlate(string oldPlate, string newPlate) {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection)) {
                string query = "update cars set plate = @NewPlate where plate = @OldPlate";
                sqlConnection.Execute(query, new { OldPlate = oldPlate, NewPlate = newPlate });
            }
        }

        public void IncreaseNumberOfViews(string carPlate) {
            using (SqlConnection connection = new SqlConnection(_dbConnection)) {
                string selectNumberOfViews = "select number_of_views from cars where plate = @Plate";
                int currentViews = connection.ExecuteScalar<int>(selectNumberOfViews, new { Plate = carPlate });

                string query = "update cars set number_of_views = @NumberOfViews where plate = @CarPlate";
                connection.Execute(query, new { NumberOfViews = selectNumberOfViews + 1, CarPlate = carPlate });
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
