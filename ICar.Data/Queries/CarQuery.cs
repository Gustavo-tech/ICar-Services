using Dapper;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;

using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Cars;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class CarQuery : ICarQuery
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        public List<Car> GetAllCars()
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT " +
                                "Plate, " +
                                "Maker, " +
                                "Model, " +
                                "MakeYear, " +
                                "MakedYear, " +
                                "Kilometers, " +
                                "TypeOfExchange, " +
                                "Price, " +
                                "Color, " +
                                "AcceptsChange, " +
                                "IpvaIsPaid, " +
                                "IsLicensed, " +
                                "GasolineType, " +
                                "IsArmored, " +
                                "Message, " +
                                "cit.Name as City, " +
                                "UserCpf, " +
                                "CompanyCnpj, " +
                                "NumberOfViews " +
                                "FROM cars c \n" +
                                "INNER JOIN cities cit ON cit.Id = c.CityId";
                return connection.Query<Car>(query).ToList();
            }
        }

        public Car GetCar(string plate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * FROM cars WHERE Plate = @Plate";
                return connection.Query<Car>(query, new { Plate = plate }).FirstOrDefault();
            }
        }

        public List<Car> GetCarsWithCnpj(string cnpj)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * FROM cars WHERE CompanyCnpj = @Cnpj";
                return connection.Query<Car>(query, new { Cnpj = cnpj }).ToList();
            }
        }

        public List<Car> GetCarsWithCpf(string cpf)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "SELECT * from cars WHERE UserCpf = @Cpf";
                return connection.Query<Car>(query, new { Cpf = cpf }).ToList();
            }
        }

        public void InsertCar(NewCar newCar)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "EXECUTE sp_insert_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
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
                    Color = newCar.Color,
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

        public void UpdateCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "EXECUTE sp_update_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
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
                    UserCpf = car.UserCpf,
                    CompanyCnpj = car.CompanyCnpj,
                });
            }
        }

        public void UpdatePlate(string oldPlate, string newPlate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
            {
                string query = "UPDATE cars SET plate = @NewPlate WHERE Plate = @OldPlate";
                sqlConnection.Execute(query, new { OldPlate = oldPlate, NewPlate = newPlate });
            }
        }

        public void IncreaseNumberOfViews(string carPlate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string SELECTNumberOfViews = "SELECT number_of_views FROM cars WHERE Plate = @Plate";
                int currentViews = connection.ExecuteScalar<int>(SELECTNumberOfViews, new { Plate = carPlate });

                string query = "UPDATE cars SET NumberOfViews = @NumberOfViews WHERE plate = @CarPlate";
                connection.Execute(query, new { NumberOfViews = SELECTNumberOfViews + 1, CarPlate = carPlate });
            }
        }

        public void DeleteCar(int id)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "DELETE FROM cars WHERE Id = @Id";
                connection.Execute(query, new { Id = id });
            }
        }
    }
}
