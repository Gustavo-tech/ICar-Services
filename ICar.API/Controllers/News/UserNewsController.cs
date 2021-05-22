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
        private readonly IUserNewsRepository _repository;

        public UserNewsController(IUserNewsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> GetNewsAsync()
        {
            try
            {
                List<UserNews> un = await _repository.GetUserNewsAsync();
                return Ok(un);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
