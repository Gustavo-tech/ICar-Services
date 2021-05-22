using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyNewsController : ControllerBase
    {
        private readonly ICompanyNewsRepository _repository;

        public CompanyNewsController(ICompanyNewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<CompanyNews> cn = await _repository.GetCompanyNewsAsync();
                return Ok(cn);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
