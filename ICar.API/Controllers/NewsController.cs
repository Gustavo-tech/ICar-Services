using ICar.API.ViewModels;
using ICar.Data.Models;
using ICar.Data.Models.System;
using ICar.Data.Queries.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ICar.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase {
        private readonly INewsQueries _newsQueries;

        public NewsController(INewsQueries newsQueries) {
            _newsQueries = newsQueries;
        }

        [HttpGet("get")]
        public IActionResult GetNews() {
            try {
                return Ok(_newsQueries.GetNews());
            }
            catch (Exception exception) {
                return Problem(title: "A problem occurred while getting the news", detail: exception.Message);
            }
        }

        [HttpPost("insert")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult InsertNews([FromBody] NewNews newNews) {
            List<InvalidReason> invalidReasons = new List<InvalidReason>();
            

            if (invalidReasons == null) {
                try {
                    News news = new News(newNews.Title, newNews.Text, newNews.Cpf, newNews.Cnpj);
                    _newsQueries.InsertNews(news);
                    return Ok("News inserted successfully");
                }
                catch (Exception exception) {
                    return Problem(title: "A problem occurred while inserting this news", detail: exception.Message);
                }
            }

            else
                return BadRequest(new {
                    InvalidReasons = invalidReasons,
                    Message = "This news is invalid"
                });
        }
    }
}
