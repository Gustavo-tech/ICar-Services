﻿using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.ViewModels.Input;
using ICar.Infrastructure.ViewModels.Output.News;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IBaseRepository _baseRepo;
        private readonly INewsRepository _newsRepo;
        private readonly IUserRepository _userRepo;

        public NewsController(IBaseRepository baseRepo, INewsRepository newsRepo, 
            IUserRepository userRepository)
        {
            _baseRepo = baseRepo;
            _newsRepo = newsRepo;
            _userRepo = userRepository;
        }

        [HttpGet("all")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateNewsAsync([FromBody] CreateNewsViewModel vm)
        {
            try
            {
                User user = await _userRepo.GetUserByEmailAsync(vm.UserEmail);
                
                if (user != null)
                {
                    News news = new(vm.Title, vm.Text, user);
                    await _baseRepo.AddAsync(news);
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
