using Dapper;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class CarQuery : ICarQuery
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        public List<CarInSystem> GetAllCars()
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "select * from cars";
                return connection.Query<CarInSystem>(query).ToList();
            }
        }

        public CarInSystem GetCar(string plate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "select * from cars where plate = @Plate";
                return connection.Query<CarInSystem>(query, new { Plate = plate }).FirstOrDefault();
            }
        }

        public List<CarInSystem> GetCarsWithCnpj(string cnpj)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "select * from cars where company_cnpj = @Cnpj";
                return connection.Query<CarInSystem>(query, new { Cnpj = cnpj }).ToList();
            }
        }

        public List<CarInSystem> GetCarsWithCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "select * from cars where user_cpf = @Cpf";
                return connection.Query<CarInSystem>(query, new { Cpf = cpf }).ToList();
            }
        }

        public void InsertCar(Car newCar)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "execute sp_insert_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                    "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                    "@Message, @City, @UserCpf, @CompanyCnpj";
                connection.Execute(query, new
                {
                    Plate = newCar.Plate,
                    Maker = newCar.Maker,
                    Model = newCar.Model,
                    MakeYear = newCar.MakeDate,
                    MakedYear = newCar.MakedDate,
                    Kilometers = newCar.KilometersTraveled,
                    TypeOfExchange = newCar.TypeOfExchange,
                    Price = newCar.Price,
                    Color = CarPropertyConverter.ConvertColorToString(newCar.Color),
                    AcceptsChange = CarPropertyConverter.ConvertBoolToBit(newCar.AcceptsChange),
                    IpvaIsPaid = CarPropertyConverter.ConvertBoolToBit(newCar.IpvaIsPaid),
                    IsLicensed = CarPropertyConverter.ConvertBoolToBit(newCar.IsLicensed),
                    GasolineType = newCar.GasolineType,
                    IsArmored = CarPropertyConverter.ConvertBoolToBit(newCar.IsArmored),
                    Message = newCar.Message,
                    City = newCar.City,
                    UserCpf = newCar.UserCpf,
                    CompanyCnpj = newCar.CompanyCnpj,
                });
            }
        }

        public void UpdateCar(CarInSystem car)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "execute sp_update_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                    "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                    "@Message, @City, @UserCpf, @CompanyCnpj";
                connection.Execute(query, new
                {
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
                    City = car.City,
                    UserCpf = car.User.Cpf,
                    CompanyCnpj = car.Company.Cnpj,
                });
            }
        }

        public void UpdatePlate(string oldPlate, string newPlate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
            {
                string query = "update cars set plate = @NewPlate where plate = @OldPlate";
                sqlConnection.Execute(query, new { OldPlate = oldPlate, NewPlate = newPlate });
            }
        }

        public void IncreaseNumberOfViews(string carPlate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string selectNumberOfViews = "select number_of_views from cars where plate = @Plate";
                int currentViews = connection.ExecuteScalar<int>(selectNumberOfViews, new { Plate = carPlate });

                string query = "update cars set number_of_views = @NumberOfViews where plate = @CarPlate";
                connection.Execute(query, new { NumberOfViews = selectNumberOfViews + 1, CarPlate = carPlate });
            }
        }

        public void DeleteCar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "delete from cars where id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
