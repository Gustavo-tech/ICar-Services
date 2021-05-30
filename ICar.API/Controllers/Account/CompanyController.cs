﻿using ICar.API.ViewModels;
using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.Repositories.Interfaces.Accounts;
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

        public CompanyController(ICompanyRepository companyQueries, ICityRepository cityRepository)
        {
            _companyRepository = companyQueries;
            _cityRepository = cityRepository;
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

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateCompany([FromBody] NewCompanyViewModel newCompany)
        //{
        //    try
        //    {
        //        Company company = await _companyRepository.GetCompanyByCnpjAsync(newCompany.Cnpj);

        //        if (company == null)
        //        {
        //            List<CompanyCity> companyCities = new();
        //            foreach (string city in newCompany.Cities)
        //            {
        //                City cityInDatabase = await _cityRepository.GetCityByNameAsync(city);

        //                if (cityInDatabase == null)
        //                {
        //                    await _cityRepository.InsertCityAsync(new City(city));
        //                }
        //            }

        //            Company companyToInsert = new(newCompany.Cnpj, newCompany.Name, newCompany.Email,
        //                newCompany.Password, DateTime.Now, null, companyCities, "client");

        //            await _companyRepository.InsertCompanyCitiesAsync(companyCities);
        //            await _companyRepository.InsertCompanyAsync(companyToInsert);

        //            return Ok(new
        //            {
        //                newCompany.Cnpj,
        //                newCompany.Email,
        //                newCompany.Name,
        //                newCompany.Cities,
        //            });
        //        }

        //        else
        //            return Problem(detail: "This company already exists");
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}
    }
}
