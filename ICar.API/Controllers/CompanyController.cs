using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.Companies;
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
        private readonly ICompanyRepository _companyQueries;

        public CompanyController(ICompanyRepository companyQueries)
        {
            _companyQueries = companyQueries;
        }

        [HttpGet("companies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public IActionResult GetCompanies()
        {
            try
            {
                List<Company> companiesInDatabase = _companyQueries.GetCompanies();
                dynamic[] companiesOutput = new dynamic[companiesInDatabase.Count];

                for (int i = 0; i <= companiesInDatabase.Count - 1; i++)
                {
                    companiesOutput[i] = new
                    {
                        CNPJ = companiesInDatabase[i].Cnpj,
                        Name = companiesInDatabase[i].Name,
                        Email = companiesInDatabase[i].Email,
                        NumberOfCarsSelling = companiesInDatabase[i].NumberOfCarsSelling,
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

        [HttpPost("create")]
        public async Task<IActionResult> InsertCompany([FromBody] NewCompany newCompany)
        {
            List<InvalidReason> invalidReasons = CompanyValidator.GetInvalidReasonsForInsert(newCompany);
            if (invalidReasons == null)
            {
                try
                {
                    await _companyQueries.InsertCompany(newCompany);
                    return Ok(new
                    {
                        CNPJ = newCompany.Cnpj,
                        Name = newCompany.Name,
                        Email = newCompany.Email,
                        Cities = newCompany.Cities,
                        Message = "Company inserted successfully"
                    });
                }
                catch (Exception exception)
                {
                    return Problem(detail: "Could not insert this company \n" +
                        $"Message: {exception.Message}");
                }
            }

            else
                return BadRequest(new
                {
                    CNPJ = newCompany.Cnpj,
                    Name = newCompany.Name,
                    Email = newCompany.Email,
                    Cities = newCompany.Cities,
                    Message = "This is a invalid company",
                    Reasons = invalidReasons
                });
        }
    }
}
