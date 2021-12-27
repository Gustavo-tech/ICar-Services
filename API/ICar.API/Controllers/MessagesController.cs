using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.ViewModels.Input.Message;
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
        private readonly IBaseRepository _baseRepository;

        public MessagesController(IMessageRepository messageRepository, IBaseRepository baseRepository)
        {
            _messageRepository = messageRepository;
            _baseRepository = baseRepository;
        }

        [HttpGet("talks")]
        public async Task<IActionResult> GetTalks()
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                List<Message> userMessages = await _messageRepository.GetMessagesByUser(userId);
                List<LastMessageWithUser> lastMessageWithUsers = Message.GetLastMessageWithUsers(userId, userMessages);

                return Ok(lastMessageWithUsers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpGet("messages/{withUserId}")]
        public async Task<IActionResult> GetMessagesWithUser([FromRoute] string withUserId)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                List<Message> messages = await _messageRepository.GetMessagesWithUser(userId, withUserId);
                return Ok(messages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageViewModel vm)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Message message = new(userId, vm.ToUserId, vm.Text);
                await _baseRepository.AddAsync(message);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }
    }
}
