using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserNewsController : ControllerBase
    {
        private readonly INewsRepository<UserNews> _repository;

        public UserNewsController(INewsRepository<UserNews> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<UserNews> un = await _repository.GetNewsAsync();
                return Ok(un);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
