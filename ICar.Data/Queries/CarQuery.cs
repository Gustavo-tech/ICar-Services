using Dapper;
using ICar.Data.Converter;
using ICar.Data.Models.Entities;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Data.Queries
{
    public class CarQuery : ICarQuery
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();
        private readonly IUserQueries _userQueries;
        private readonly ICompanyQueries _companyQueries;

        public CarQuery(IUserQueries userQueries, ICompanyQueries companyQueries)
        {
            _userQueries = userQueries;
            _companyQueries = companyQueries;
        }

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
                return connection.QueryAsync<Car>(query).Result.ToList();
            }
        }

        public Car GetCar(string plate)
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
                                "INNER JOIN cities cit ON cit.Id = c.CityId\n" +
                                "WHERE Plate = @Plate";
                return connection.QueryAsync<Car>(query, new { Plate = plate }).Result.FirstOrDefault();
            }
        }

        public List<Car> GetCarsWithCnpj(string cnpj)
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
                                "INNER JOIN cities cit ON cit.Id = c.CityId\n" +
                                "WHERE CompanyCnpj = @Cnpj";
                return connection.QueryAsync<Car>(query, new { Cnpj = cnpj }).Result.ToList();
            }
        }

        public List<Car> GetCarsWithCpf(string cpf)
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
                                "INNER JOIN cities cit ON cit.Id = c.CityId\n" +
                                "WHERE UserCpf = @Cpf";
                return connection.QueryAsync<Car>(query, new { Cpf = cpf }).Result.ToList();
            }
        }

        public async Task InsertCar(NewCar newCar)
        {
            if (GetCar(newCar.Plate) == null)
            {
                if (newCar.UserCpf != "")
                {
                    if (_userQueries.GetUserByCpf(newCar.UserCpf) != null)
                    {
                        using (SqlConnection connection = new SqlConnection(_dbConnection))
                        {
                            string query = "EXECUTE sp_insert_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                                "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                                "@Message, @City, @UserCpf, null";
                           await connection.ExecuteAsync(query, new
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
                            });
                        }
                    }
                    else
                    {
                        throw new Exception("This CPF isn't in our database");
                    }
                }

                else
                {
                    if (_companyQueries.GetCompanyByCnpj(newCar.CompanyCnpj) != null)
                    {
                        using (SqlConnection connection = new SqlConnection(_dbConnection))
                        {
                            string query = "EXECUTE sp_insert_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                                "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                                "@Message, @City, null, @CompanyCnpj";
                            await connection.ExecuteAsync(query, new
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
                                CompanyCnpj = newCar.CompanyCnpj
                            });
                        }
                    }
                    else
                    {
                        throw new Exception("This company isn't registered in our database");
                    }
                }
            }
            
            else
            {
                throw new Exception("This car already exists in our database");
            }
        }

        public async Task InsertCarPictures(List<string> pictures, string carPlate)
        {
            if (pictures != null)
            {
                using (SqlConnection connection = new SqlConnection(_dbConnection))
                {
                    foreach (string p in pictures)
                    {
                        string query = "INSERT INTO car_images VALUES (@Stream, @Plate)";
                        await connection.ExecuteAsync(query, new { Stream = p, Plate = carPlate });
                    }
                }
            }
        }

        public async Task UpdateCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "EXECUTE sp_update_car @Plate, @Maker, @Model, @MakeYear, @MakedYear, @Kilometers, " +
                    "@TypeOfExchange, @Price, @Color, @AcceptsChange, @IpvaIsPaid, @IsLicensed, @GasolineType, @IsArmored, " +
                    "@Message, @City, @UserCpf, @CompanyCnpj";
                await connection.ExecuteAsync(query, new
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

        public async Task UpdatePlate(string oldPlate, string newPlate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_dbConnection))
            {
                string query = "UPDATE cars SET plate = @NewPlate WHERE Plate = @OldPlate";
                await sqlConnection.ExecuteAsync(query, new { OldPlate = oldPlate, NewPlate = newPlate });
            }
        }

        public async Task IncreaseNumberOfViews(string carPlate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string selectNumberOfViews = "SELECT number_of_views FROM cars WHERE Plate = @Plate";
                int currentViews = connection.ExecuteScalar<int>(selectNumberOfViews, new { Plate = carPlate });

                string query = "UPDATE cars SET NumberOfViews = @NumberOfViews WHERE plate = @CarPlate";
                await connection.ExecuteAsync(query, new { NumberOfViews = currentViews + 1, CarPlate = carPlate });
            }
        }

        public async Task DeleteCarPictures(string plate)
        {
            using (SqlConnection con = new SqlConnection(_dbConnection))
            {
                string query = "DELETE FROM car_images WHERE CarPlate = @Plate";
                await con.ExecuteAsync(query, new { Plate = plate });
            }
        }

        public async Task DeleteCar(string plate)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "DELETE FROM cars WHERE Plate = @Plate";
                await connection.ExecuteAsync(query, new { Plate = plate });
            }
        }
    }
}
