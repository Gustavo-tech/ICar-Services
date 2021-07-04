using ICar.API.Generators;
using ICar.API.ViewModels.Company;
using ICar.Infrastructure.Database.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
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
        private readonly IBaseRepository _baseRepository;

        public CompanyController(
            ICompanyRepository companyQueries,
            ICityRepository cityRepository,
            IBaseRepository baseRepository
            )
        {
            _companyRepository = companyQueries;
            _cityRepository = cityRepository;
            _baseRepository = baseRepository;
        }

        //[HttpGet("companies")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        //public async Task<IActionResult> GetCompanies()
        //{
        //    try
        //    {
        //        List<Company> companiesInDatabase = await _companyRepository.GetCompaniesAsync();
        //        dynamic[] companiesOutput = new dynamic[companiesInDatabase.Count];

        //        for (int i = 0; i <= companiesInDatabase.Count - 1; i++)
        //        {
        //            companiesOutput[i] = CompanyOutputFactory.GenerateCompanyOutput(companiesInDatabase[i]);
        //        }

        //        return Ok(companiesOutput);
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateCompany([FromBody] CompanyViewModel insert)
        //{
        //    try
        //    {
        //        Company company = await _companyRepository.GetCompanyByCnpjAsync(insert.Cnpj);

        //        if (company == null)
        //        {
        //            Company companyToInsert = new(insert.Cnpj, insert.Name, insert.Email,
        //                insert.Password, "client");

        //            await _baseRepository.AddAsync(companyToInsert);

        //            dynamic output = new
        //            {
        //                CNPJ = insert.Cnpj,
        //                insert.Name,
        //                insert.Email,
        //                Message = "Company inserted successfully"
        //            };

        //            return Ok(output);
        //        }

        //        else
        //            return Problem(detail: "This company already exists");
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}

        //[HttpPut("update")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<IActionResult> UpdateCompanyAsync([FromBody] CompanyViewModel update)
        //{
        //    try
        //    {
        //        Company companyInDatabase = await _companyRepository.GetCompanyByCnpjAsync(update.Cnpj);
        //        if (companyInDatabase != null)
        //        {
        //            companyInDatabase.UserName = update.Name;
        //            companyInDatabase.Email = update.Email;
        //            companyInDatabase.Password = update.Password;

        //            await _baseRepository.UpdateAsync(companyInDatabase);
        //            return Ok();
        //        }

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}

        //[HttpDelete("delete")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public async Task<IActionResult> DeleteCompanyAsync([FromBody] DeleteCompanyViewModel delete)
        //{
        //    try
        //    {
        //        Company companyInDatabase = await _companyRepository.GetCompanyByEmailAsync(delete.Email);

        //        if (companyInDatabase.Password == delete.Password)
        //        {
        //            await _baseRepository.DeleteAsync(companyInDatabase);
        //            return Ok();
        //        }
        //        else
        //            return BadRequest();
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}
    }
}
