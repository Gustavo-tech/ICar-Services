using ICar.API.Generators;
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
    [Route("[controller]")]
    [ApiController]
    public class CompanyNewsController : ControllerBase
    {
        private readonly INewsRepository _repository;

        public CompanyNewsController(INewsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<News> companyNews = await _repository.GetCompanyNewsAsync();
                dynamic[] output = NewsOutputGenerator.GenerateCompanyNewsOutput(companyNews);
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
