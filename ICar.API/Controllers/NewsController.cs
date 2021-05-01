using ICar.API.Validations;
using ICar.Data.Models.Entities;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using ICar.Data.ViewModels.News;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsQueries _newsQueries;

        public NewsController(INewsQueries newsQueries)
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
        public IActionResult InsertNews([FromBody] News newNews)
        {

            List<InvalidReason> invalidReasons = NewsValidator.GetInvalidReasonsForInsert(newNews);
            if (invalidReasons == null)
            {
                try
                {
                    bool newsIsFromACompany = newNews.Cnpj != "";
                    _newsQueries.InsertNews(newNews, newsIsFromACompany);
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

        //[HttpPut("update")]
        //public IActionResult UpdateNews([FromBody] UpdatedNews updatedNews)
        //{
        //    List<InvalidReason> invalidReasons = NewsValidator.GetInvalidReasonsForInsert(updatedNews);

        //    if (invalidReasons == null)
        //    {
        //        try
        //        {
        //            _newsQueries.UpdateNews(updatedNews.Id, updatedNews);
        //            return Ok("News updated successfully");
        //        }
        //        catch (Exception e)
        //        {
        //            return Problem(title: "A problem occurred while updating this news", detail: e.Message);
        //        }
        //    }

        //    else
        //        return BadRequest(new
        //        {
        //            InvalidReasons = invalidReasons,
        //            Message = "This update is invalid"
        //        });
        //}

        [HttpDelete("delete")]
        public IActionResult DeleteNews([FromBody] DeleteNews deleteNews)
        {
            try
            {
                _newsQueries.DeleteNews(deleteNews.Id);
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
