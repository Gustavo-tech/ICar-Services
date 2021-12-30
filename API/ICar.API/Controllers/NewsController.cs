using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.ViewModels.Input;
using ICar.Infrastructure.ViewModels.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IBaseRepository _baseRepo;
        private readonly INewsRepository _newsRepo;

        public NewsController(IBaseRepository baseRepo, INewsRepository newsRepo)
        {
            _baseRepo = baseRepo;
            _newsRepo = newsRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<News> news = await _newsRepo.GetNewsAsync();
                NewsOutputViewModel[] viewModels = news.Select(x => x.ToNewsOutputViewModel()).ToArray();
                return Ok(viewModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpGet("mynews")]
        public async Task<IActionResult> GetUserNewsAsync()
        {
            try
            {
                string authorId = HttpContext.GetUserObjectId();
                List<News> userNews = await _newsRepo.GetNewsByAuthorIdAsync(authorId);
                NewsOutputViewModel[] output = userNews.Select(x => x.ToNewsOutputViewModel()).ToArray();

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                News news = await _newsRepo.GetNewsByIdAsync(id);

                if (news != null)
                {
                    NewsOutputViewModel vm = news.ToNewsOutputViewModel();
                    return Ok(vm);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewsAsync([FromBody] CreateNewsViewModel vm)
        {
            try
            {
                string authorId = HttpContext.GetUserObjectId();
                News news = new(vm.Title, vm.Text, authorId);
                await _baseRepo.AddAsync(news);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateNewsAsync([FromBody] UpdateNewsViewModel vm)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                News news = await _newsRepo.GetNewsByIdAsync(vm.Id);
                bool userIsAuthor = news.AuthorId == userId;

                if (userIsAuthor)
                {
                    news.Update(vm.Title, vm.Text);
                    await _baseRepo.UpdateAsync(news);
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNewsAsync([FromBody] DeleteNewsViewModel vm)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                News news = await _newsRepo.GetNewsByIdAsync(vm.Id);
                bool userIsAuthor = news.AuthorId == userId;

                if (userIsAuthor)
                {
                    await _baseRepo.DeleteAsync(news);
                    return Ok();
                }

                return BadRequest();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }
    }
}
