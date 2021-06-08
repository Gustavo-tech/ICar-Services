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
                dynamic[] output = NewsOutputFactory.GenerateCompanyNewsOutput(companyNews);
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertNewsAsync([FromBody] CompanyNewsViewModel create)
        {
            try
            {
                if (await _newsRepository.GetNewsAsync(create.Title, create.Text) == null)
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

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateNewsAsync([FromBody] UpdateCompanyNewsViewModel update)
        {
            try
            {
                News newsInDatabase = await _newsRepository.GetNewsAsync(update.Id);
                if (newsInDatabase != null)
                {
                    newsInDatabase.Title = update.Title;
                    newsInDatabase.Text = update.Text;
                    newsInDatabase.LastUpdate = DateTime.Now;
                    await _baseRepository.UpdateAsync(newsInDatabase);
                    return Ok();
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteNewsAsync([FromRoute] int id)
        {
            try
            {
                News news = await _newsRepository.GetNewsAsync(id);
                await _baseRepository.DeleteAsync(news);
                return Ok();
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
