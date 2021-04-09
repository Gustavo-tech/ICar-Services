using ICar.API.Auth.Contracts;
using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyQueries _companyQueries;
        private readonly IAuthService _auth;

        public CompanyController(ICompanyQueries companyQueries, IAuthService authService)
        {
            _companyQueries = companyQueries;
            _auth = authService;
        }

        [HttpGet("companies")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetCompanies()
        {
            try
            {
                return Ok(_companyQueries.GetCompanies());
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
