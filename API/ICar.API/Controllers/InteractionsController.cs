using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.ViewModels.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionRepository _interactionRepository;
        private readonly IMessageRepository _messageRepository;

        public InteractionsController(IInteractionRepository interactionRepository, IMessageRepository messageRepository)
        {
            _interactionRepository = interactionRepository;
            _messageRepository = messageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyInteractionsAsync()
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                List<Interaction> userInteractions = await _interactionRepository.GetUserInteractionsAsync(userId);
                List<InteractionOutputViewModel> interactionOutputs = new();

                foreach(Interaction interaction in userInteractions)
                {
                    Message message = await _messageRepository.GetLastMessageWithUserAsync(userId, 
                        interaction.WithUserId, interaction.SubjectId);

                    InteractionOutputViewModel interactionOutput = interaction.ToInteractionOutputViewModel(message.Text);
                    interactionOutputs.Add(interactionOutput);
                }

                return Ok(interactionOutputs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }
    }
}
