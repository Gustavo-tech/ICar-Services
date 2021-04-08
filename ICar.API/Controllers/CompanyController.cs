using ICar.Data.Models;
using ICar.Data.Queries.Contracts;
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
        public CompanyController(ICompanyQueries companyQueries)
        {
            _companyQueries = companyQueries;
        }

        [HttpGet("companies")]
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
