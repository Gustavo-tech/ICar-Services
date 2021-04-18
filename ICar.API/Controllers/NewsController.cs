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
        private readonly IUserQueries _userQueries;
        private readonly ICompanyQueries _companyQueries;

        public NewsController(INewsQueries newsQueries, IUserQueries userQueries, ICompanyQueries companyQueries) {
            _newsQueries = newsQueries;
            _userQueries = userQueries;
            _companyQueries = companyQueries;
        }

        private News InstantiateNewsAccordingToAuthor(NewNews newNews) {
            if (newNews.Cpf != null) {
                News news = new News(newNews.Title, newNews.Text, null, null);
                User user = _userQueries.GetUserByCpf(newNews.Cpf);
                news.User = user;
                return news;
            }

            else if (newNews.Cnpj != null) {
                News news = new News(newNews.Title, newNews.Text, null, null);
                Company company = _companyQueries.GetCompanyByCnpj(newNews.Cnpj);
                news.Company = company;
                return news;
            }

            else {
                throw new InvalidOperationException("News should contain at least one author");
            }
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
                    News news = InstantiateNewsAccordingToAuthor(newNews);
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
