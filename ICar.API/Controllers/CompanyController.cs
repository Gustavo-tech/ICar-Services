using ICar.API.ViewModels;
using ICar.Data.Models;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase {
        private readonly ICompanyQueries _companyQueries;
        private readonly CompanyValidator _cpValidator;

        public CompanyController(ICompanyQueries companyQueries) {
            _companyQueries = companyQueries;
            _cpValidator = new CompanyValidator();
        }

        [HttpGet("companies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public IActionResult GetCompanies()
        {
            try
            {
                return Ok(_companyQueries.GetCompanies());
            }
            catch (Exception e) {
                return Problem(e.Message);
            }
        }

        [HttpPost("insert")]
        public IActionResult InsertCompany([FromBody] NewCompany newCompany) {
            Company company = new Company(
                newCompany.Cnpj,
                newCompany.Name,
                newCompany.Email,
                newCompany.Password,
                newCompany.Cities);

            List<InvalidReason> invalidReasons = _cpValidator.GetInvalidReasons(company);
            if (invalidReasons == null) {
                try {
                    _companyQueries.InsertCompany(company, false);
                    return Ok(new {
                        CNPJ = company.Cnpj,
                        Name = company.Name,
                        Email = company.Email,
                        Cities = company.Cities,
                        Message = "Company inserted successfully"
                    });
                }
                catch (Exception exception) {
                    return Problem(detail: "Could not insert this company \n" +
                        $"Message: {exception.Message}");
                }
            }

            else
                return BadRequest(new {
                    CNPJ = company.Cnpj,
                    Name = company.Name,
                    Email = company.Email,
                    Cities = company.Cities,
                    Message = "This is a invalid company",
                    Reasons = invalidReasons
                });
    }
}
