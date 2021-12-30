using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("{withUserId}/{subjectId}")]
        public async Task<IActionResult> GetMessagesWithUser([FromRoute] string withUserId, string subjectId)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                List<Message> messages = await _messageRepository.GetMessagesWithUserAsync(userId, withUserId, subjectId);
                return Ok(messages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }
    }
}
