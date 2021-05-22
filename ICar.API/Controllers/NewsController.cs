using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.ViewModels.News;
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
    public class NewsController : ControllerBase
    {
        private readonly IUserNewsRepository _newsRepository;

        public NewsController(IUserNewsRepository newsQueries)
        {
            _newsRepository = newsQueries;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetNews()
        {
            try
            {
                List<News> news = await _newsRepository.GetNewsAsync();
                return Ok(news);
            }
            catch (Exception exception)
            {
                return Problem(title: "A problem occurred while getting the news", detail: exception.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteNews([FromRoute] int id)
        {
            try
            {
                await _newsRepository.DeleteNewsAsync(id);
                return Ok("This news was deleted successfully");
            }
            catch (Exception e)
            {
                return Problem(title: "A problem happened while deleting the news with this id",
                    detail: e.Message);
            }
        }
    }
}
