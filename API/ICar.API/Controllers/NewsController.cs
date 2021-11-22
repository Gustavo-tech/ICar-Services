using ICar.API.ViewModels.UserNews;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                dynamic[] output = userNews.Select(x => x.ToNewsOutputViewModel()).ToArray();
                return Ok(output);
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
                    newsInDatabase.Update(update.Title, update.Text);
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
