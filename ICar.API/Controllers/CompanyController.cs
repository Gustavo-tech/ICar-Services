using ICar.API.Generators;
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
                    companiesOutput[i] = CompanyOutputGenerator.GenerateCompanyOutput(companiesInDatabase[i]);
                }

                return Ok(companiesOutput);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyViewModel insert)
        {
            try
            {
                Company company = await _companyRepository.GetCompanyByCnpjAsync(insert.Cnpj);

                if (company == null)
                {
                    await HandleCitiesInsertionAsync(insert.Cnpj, insert.Cities);
                    Company companyToInsert = new(insert.Cnpj, insert.Name, insert.Email,
                        insert.Password, "client");

                    await _baseRepository.AddAsync(companyToInsert);
                    await InsertCompanyCityIfDoesntExistAsync(insert.Cnpj, insert.Cities);

                    dynamic output = new
                    {
                        CNPJ = insert.Cnpj,
                        insert.Name,
                        insert.Email,
                        insert.Cities,
                        Message = "Company inserted successfully"
                    };

                    return Ok(output);
                }

                else
                    return Problem(detail: "This company already exists");
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] CompanyViewModel update)
        {
            try
            {
                Company companyInDatabase = await _companyRepository.GetCompanyByCnpjAsync(update.Cnpj);
                if (companyInDatabase != null)
                {
                    companyInDatabase.Name = update.Name;
                    companyInDatabase.Email = update.Email;
                    companyInDatabase.Password = update.Password;

                    return Ok();
                }

                return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        private async Task HandleCitiesInsertionAsync(string companyCnpj, List<string> cities)
        {
            foreach (string cityName in cities)
            {
                City cityInDatabase = await _cityRepository.GetCityByNameAsync(cityName);

                if (cityInDatabase == null)
                {
                    City cityToInsert = new(cityName);
                    await _baseRepository.AddAsync(cityToInsert);
                }
            }
        }

        private async Task InsertCompanyCityIfDoesntExistAsync(string companyCnpj, List<string> cities)
        {
            try
            {
                foreach (string cityName in cities)
                {
                    City city = await _cityRepository.GetCityByNameAsync(cityName);
                    CompanyCity companyCityInDatabase = await _companyCityRepository
                        .GetCompanyCityAsync(companyCnpj, city.Id.Value);

                    if (companyCityInDatabase == null)
                    {
                        CompanyCity companyCityToInsert = new() { CompanyCnpj = companyCnpj, CityId = city.Id.Value };
                        await _baseRepository.AddAsync(companyCityToInsert);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
