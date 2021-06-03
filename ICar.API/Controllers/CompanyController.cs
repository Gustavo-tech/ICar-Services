using ICar.API.ViewModels;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICompanyCityRepository _companyCityRepository;
        private readonly IBaseRepository _baseRepository;

        public CompanyController(
            ICompanyRepository companyQueries,
            ICityRepository cityRepository,
            ICompanyCityRepository companyCityRepository,
            IBaseRepository baseRepository
            )
        {
            _companyRepository = companyQueries;
            _cityRepository = cityRepository;
            _companyCityRepository = companyCityRepository;
            _baseRepository = baseRepository;
        }

        [HttpGet("companies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                List<Company> companiesInDatabase = await _companyRepository.GetCompaniesAsync();
                dynamic[] companiesOutput = new dynamic[companiesInDatabase.Count];

                for (int i = 0; i <= companiesInDatabase.Count - 1; i++)
                {
                    companiesOutput[i] = new
                    {
                        CNPJ = companiesInDatabase[i].Cnpj,
                        companiesInDatabase[i].Name,
                        companiesInDatabase[i].Email,
                        companiesInDatabase[i].AccountCreationDate,
                        companiesInDatabase[i].Role,
                        companiesInDatabase[i].Cities
                    };
                }

                return Ok(companiesOutput);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] NewCompanyViewModel newCompany)
        {
            try
            {
                Company company = await _companyRepository.GetCompanyByCnpjAsync(newCompany.Cnpj);

                if (company == null)
                {
                    List<City> companyCities = await HandleCitiesInsertionAsync(newCompany.Cnpj, newCompany.Cities);
                    Company companyToInsert = new(newCompany.Cnpj, newCompany.Name, newCompany.Email,
                        newCompany.Password, companyCities, "client");

                    await _baseRepository.AddAsync(companyToInsert);

                    return Ok(new
                    {
                        newCompany.Cnpj,
                        newCompany.Email,
                        newCompany.Name,
                        newCompany.Cities,
                    });
                }

                else
                    return Problem(detail: "This company already exists");
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        private async Task<List<City>> HandleCitiesInsertionAsync(string companyCnpj, List<string> cities)
        {
            List<City> companyCities = new();
            foreach (string city in cities)
            {
                City cityResult = await InsertCityIfDoesntExistsAsync(city);
                await InsertCompanyCityIfDoesnExistAsync(companyCnpj, cityResult.Id.Value);
                companyCities.Add(cityResult);
            }

            return companyCities;
        }

        private async Task<City> InsertCityIfDoesntExistsAsync(string city)
        {
            City cityInDatabase = await _cityRepository.GetCityByNameAsync(city);

            if (cityInDatabase == null)
            {
                City cityToInsert = new(city);
                await _baseRepository.AddAsync(cityToInsert);
                return cityToInsert;
            }
            else
                return cityInDatabase;
        }

        private async Task InsertCompanyCityIfDoesnExistAsync(string companyCnpj, int cityId)
        {
            try
            {
                List<CompanyCity> companyCities = await _companyCityRepository.GetCompanyCitiesAsync(companyCnpj);

                foreach (CompanyCity companyCity in companyCities)
                {
                    CompanyCity companyCityInDatabase = await _companyCityRepository.GetCompanyCityAsync(companyCnpj, cityId);

                    if (companyCityInDatabase == null)
                    {
                        CompanyCity companyCityToInsert = new() { CityId = cityId, CompanyCnpj = companyCnpj };
                        await _baseRepository.AddAsync(companyCityToInsert);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private dynamic[] GenerateCompanyOutput(List<Company> companies)
        {

        }
    }
}
