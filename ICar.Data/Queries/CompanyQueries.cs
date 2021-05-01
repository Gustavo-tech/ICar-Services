using Dapper;
using ICar.Data.Models.Entities;
using ICar.Data.Models.EntitiesInSystem;
using ICar.Data.Queries.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ICar.Data.Queries
{
    public class CompanyQueries : ICompanyQueries
    {
        private readonly string _dbConnection = DatabaseConnectionFactory.GetICarConnection();

        private List<string> GetCompanyCities(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = $"execute sp_get_company_cities '{email}'";
                return connection.Query<string>(query).ToList();
            }
        }

        public List<CompanyInSystem> GetCompanies(int? quantity = null)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                if (quantity != null)
                {
                    string quantityQuery = $"select top {quantity} from companies";
                    return connection.Query<CompanyInSystem>(quantityQuery).ToList();
                }

                string selectQuery = "select * from companies";
                List<CompanyInSystem> companies = connection.Query<CompanyInSystem>(selectQuery).ToList();

                foreach (CompanyInSystem company in companies)
                {
                    company.Cities = GetCompanyCities(company.Email);
                }

                return companies;
            }

        }

        public CompanyInSystem GetCompanyByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                List<string> companyCities = GetCompanyCities(email);

                string query = "select * from companies where Email = @Email";
                CompanyInSystem company = connection.Query<CompanyInSystem>(query, new { Email = email }).FirstOrDefault();

                company.Cities = companyCities;
                return company;
            }
        }

        public CompanyInSystem GetCompanyByCnpj(string cnpj)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                List<string> companyCities = GetCompanyCities(cnpj);
                string query = "select * from companies where cnpj = @Cnpj";
                CompanyInSystem company = connection.Query<CompanyInSystem>(query, new { Cnpj = cnpj }).FirstOrDefault();
                company.Cities = companyCities;
                return company;
            }
        }

        public void InsertCompany(Company company, bool isAdmin = false)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnection))
            {
                string query = "EXECUTE sp_insert_company @Cnpj, @Name, @Email, @Password, @Role, @Cities";
                connection.Query(query, new
                {
                    Cnpj = company.Cnpj,
                    Name = company.Name,
                    Email = company.Email,
                    Password = company.Password,
                    Role = isAdmin ? "admin" : "client",
                    Cities = company.Cities
                });
            }
        }
    }
}
