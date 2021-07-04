using ICar.API.Generators;
using ICar.API.ViewModels.CompayNews;
using ICar.API.ViewModels.UserNews;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly IBaseRepository _baseRepository;

        public NewsController(INewsRepository newsRepository, IBaseRepository baseRepository)
        {
            _newsRepository = newsRepository;
            _baseRepository = baseRepository;
        }

        [HttpGet("user/get")]
        public async Task<IActionResult> GetUserNewsAsync()
        {
            try
            {
                List<News> userNews = await _newsRepository.GetUserNewsAsync();
                dynamic[] output = NewsOutputFactory.GenerateUserNewsOutput(userNews);
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("company/get")]
        public async Task<IActionResult> GetCompanyNewsAsync()
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

        [HttpPost("user/create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertUserNewsAsync([FromBody] UserNewsViewModel create)
        {
            try
            {
                if (await _newsRepository.GetNewsAsync(create.Title, create.Text) == null)
                {
                    News newsToInsert = new(create.Title, create.Text, create.Cpf, false);
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

        [HttpPost("company/create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertCompanyNewsAsync([FromBody] CompanyNewsViewModel create)
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

        [HttpPut("users/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateUserNewsAsync([FromBody] UpdateUserNewsViewModel update)
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

        [HttpPut("company/update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateCompanyNewsAsync([FromBody] UpdateCompanyNewsViewModel update)
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
