using ICar.API.Generators;
using ICar.API.ViewModels.CompayNews;
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
        private readonly INewsRepository _newsRepository;
        private readonly IBaseRepository _baseRepository;

        public CompanyNewsController(INewsRepository repository, IBaseRepository baseRepository)
        {
            _newsRepository = repository;
            _baseRepository = baseRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<News> companyNews = await _newsRepository.GetCompanyNewsAsync();
                dynamic[] output = NewsOutputGenerator.GenerateCompanyNewsOutput(companyNews);
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> InsertNewsAsync([FromBody] CompanyNewsViewModel create)
        {
            try
            {
                if (await _newsRepository.GetCompanyNewsAsync(create.Title, create.Text) == null)
                {
                    News newsToInsert = new(create.Title, create.Text, create.CompanyCnpj);
                    await _baseRepository.AddAsync(newsToInsert);
                    return Ok(create);
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
