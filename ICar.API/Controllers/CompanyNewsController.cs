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
        private readonly INewsRepository<CompanyNews> _repository;

        public CompanyNewsController(INewsRepository<CompanyNews> repository)
        {
            _repository = repository;
        }

        [HttpGet("get")]
        [Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = "client, admin")]
        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<CompanyNews> cn = await _repository.GetNewsAsync();
                return Ok(cn);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
