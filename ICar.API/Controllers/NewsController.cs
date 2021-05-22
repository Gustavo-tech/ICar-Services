using ICar.API.Validations;
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
        private readonly INewsRepository _newsQueries;

        public NewsController(INewsRepository newsQueries)
        {
            _newsQueries = newsQueries;
        }

        [HttpGet("get")]
        public IActionResult GetNews()
        {
            try
            {
                return Ok(_newsQueries.GetNews());
            }
            catch (Exception exception)
            {
                return Problem(title: "A problem occurred while getting the news", detail: exception.Message);
            }
        }

        [HttpPost("insert")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> InsertNews([FromBody] NewNews newNews)
        {

            List<InvalidReason> invalidReasons = NewsValidator.GetInvalidReasonsForInsert(newNews);
            if (invalidReasons == null)
            {
                try
                {
                    bool newsIsFromACompany = newNews.Cnpj != "";
                    await _newsQueries.InsertNews(newNews, newsIsFromACompany);
                    return Ok("News inserted successfully");
                }
                catch (Exception exception)
                {
                    return Problem(title: "A problem occurred while inserting this news", detail: exception.Message);
                }
            }

            else
                return BadRequest(new
                {
                    InvalidReasons = invalidReasons,
                    Message = "This news is invalid"
                });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNews([FromBody] DeleteNews deleteNews)
        {
            try
            {
                await _newsQueries.DeleteNews(deleteNews.Id);
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
