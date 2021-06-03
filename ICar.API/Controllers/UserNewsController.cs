﻿using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
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
    public class UserNewsController : ControllerBase
    {
        private readonly INewsRepository<UserNews> _repository;

        public UserNewsController(INewsRepository<UserNews> repository)
        {
            _repository = repository;
        }

        [HttpGet("get")]
        [Authorize(JwtBearerDefaults.AuthenticationScheme, Roles = "client, admin")]
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