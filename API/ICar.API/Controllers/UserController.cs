using ICar.Infrastructure.Models;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICar.API.ViewModels.User;
using ICar.Infrastructure.Repositories;
using ICar.Infrastructure.Repositories.Interfaces;

namespace ICar.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messagesRepository;
        private readonly IBaseRepository _baseRepo;

        public UserController(IUserRepository userRepository, IMessageRepository messagesRepository, IBaseRepository baseRepo)
        {
            _userRepository = userRepository;
            _messagesRepository = messagesRepository;
            _baseRepo = baseRepo;
        }

        [HttpGet("info/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserInformation([FromRoute] string email)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                return Ok(new
                {
                    user.Email,
                    user.UserName,
                    user.AccountCreationDate
                });
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("logins/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetLogins([FromRoute] string email)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(email);
                dynamic[] output = user.Logins.Select(x => x.GenerateLoginOutput()).ToArray();
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("talks/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetTalks([FromRoute] string email)
        {
            try
            {
                User userLogged = await _userRepository.GetUserByEmailAsync(email);
                List<Message> messages = await _messagesRepository.GetMessagesByEmail(email);
                List<User> usersTalked = new();
                List<Talk> talks = new();

                foreach(Message message in messages)
                {
                    if (!Infrastructure.Models.User.CheckIfListAlreadyContainsTalkedTo(usersTalked, message))
                    {
                        if (message.FromUser.Email != userLogged.Email)
                        {
                            usersTalked.Add(message.FromUser);
                        }
                        else
                        {
                            usersTalked.Add(message.ToUser);
                        }
                    }
                }
                foreach (User user in usersTalked)
                {
                    Message lastMessage = await _messagesRepository.GetLastMessageWith(email, user.Email);
                    string sendLast = lastMessage.FromUser.UserName;
                    talks.Add(lastMessage.ToTalk(sendLast));
                }

                return Ok(talks);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("messages/{emailUser}/{emailTalked}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetMessages(string emailUser, string emailTalked)
        {
            try
            {
                User user = await _userRepository.GetUserByEmailAsync(emailUser);
                User talked = await _userRepository.GetUserByEmailAsync(emailTalked);

                if (user is null || talked is null)
                    return NotFound(new
                    {
                        Message = "One or both of the users were not found"
                    });

                List<Message> messages = await _messagesRepository.GetMessagesWith(emailUser, emailTalked);
                dynamic[] output = messages.Select(m => m.ToApiOutput()).ToArray();
                return Ok(output);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost("message")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SendMessage([FromBody] SendMessage sendMessage)
        {
            try
            {
                User from = await _userRepository.GetUserByEmailAsync(sendMessage.EmailFrom);
                User to = await _userRepository.GetUserByEmailAsync(sendMessage.EmailTo);

                if (from is null || to is null)
                {
                    return NotFound(new
                    {
                        Message = "User not found with this Email"
                    });
                }

                Message message = new(from, to, sendMessage.Text);
                await _baseRepo.AddAsync(message);
                return Ok();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
    }
}
