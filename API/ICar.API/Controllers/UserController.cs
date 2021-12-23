using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.ViewModels.Input.Message;
using ICar.Infrastructure.ViewModels.Output.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        
        public UserController(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetUserInformation()
        {
            string userId = HttpContext.GetUserObjectId();
            User user = await _userRepo.GetUserInfo(userId);

            return Ok(user);
        }

        //[HttpGet("talks/{email}")]
        //public async Task<IActionResult> GetTalks([FromRoute] string email)
        //{
        //    try
        //    {
        //        User userLogged = await _userRepository.GetUserByEmailAsync(email);
        //        List<Message> messages = await _messagesRepository.GetMessagesByEmail(email);
        //        List<User> usersTalked = new();
        //        List<Talk> talks = new();

        //        foreach (Message message in messages)
        //        {
        //            if (!Infrastructure.Models.User.CheckIfListAlreadyContainsTalkedTo(usersTalked, message))
        //            {
        //                if (message.FromUser.Email != userLogged.Email)
        //                {
        //                    usersTalked.Add(message.FromUser);
        //                }
        //                else
        //                {
        //                    usersTalked.Add(message.ToUser);
        //                }
        //            }
        //        }
        //        foreach (User user in usersTalked)
        //        {
        //            Message lastMessage = await _messagesRepository.GetLastMessageWith(email, user.Email);
        //            string sendLast = lastMessage.FromUser.UserName;
        //            talks.Add(lastMessage.ToTalk(sendLast));
        //        }

        //        return Ok(talks);
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}

        //[HttpGet("messages/{emailUser}/{emailTalked}")]
        //public async Task<IActionResult> GetMessages(string emailUser, string emailTalked)
        //{
        //    try
        //    {
        //        User user = await _userRepository.GetUserByEmailAsync(emailUser);
        //        User talked = await _userRepository.GetUserByEmailAsync(emailTalked);

        //        if (user is null || talked is null)
        //            return NotFound(new
        //            {
        //                Message = "One or both of the users were not found"
        //            });

        //        List<Message> messages = await _messagesRepository.GetMessagesWith(emailUser, emailTalked);
        //        MessageOutputViewModel[] output = messages.Select(m => m.ToMessageOutputViewModel()).ToArray();
        //        return Ok(output);
        //    }
        //    catch (Exception)
        //    {
        //        return Problem();
        //    }
        //}

        //[HttpPost("message")]
        //public async Task<IActionResult> SendMessage([FromBody] SendMessageViewModel sendMessage)
        //{
        //    try
        //    {
        //        User from = await _userRepository.GetUserByEmailAsync(sendMessage.EmailFrom);
        //        User to = await _userRepository.GetUserByEmailAsync(sendMessage.EmailTo);

        //        if (from is null || to is null)
        //        {
        //            return NotFound(new
        //            {
        //                Message = "User not found with this Email"
        //            });
        //        }

        //        Message message = new(from, to, sendMessage.Text);
        //        await _baseRepo.AddAsync(message);
        //        return Ok();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return Problem();
        //    }
        //}
    }
}
