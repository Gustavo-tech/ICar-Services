using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Repositories.Interfaces;
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

        public CompanyController(ICompanyRepository companyQueries)
        {
            _companyRepository = companyQueries;
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
                        Name = companiesInDatabase[i].Name,
                        Email = companiesInDatabase[i].Email,
                        AccountCreationDate = companiesInDatabase[i].AccountCreationDate,
                        Role = companiesInDatabase[i].Role,
                        Cities = companiesInDatabase[i].Cities
                    };
                }

                return Ok(companiesOutput);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
