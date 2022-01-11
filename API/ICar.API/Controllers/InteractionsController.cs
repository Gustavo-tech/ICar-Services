using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.ViewModels.Input;
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
        private readonly ICarRepository _carRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IBaseRepository _baseRepository;

        public InteractionsController(IInteractionRepository interactionRepository, IMessageRepository messageRepository,
            ICarRepository carRepository, IContactRepository contactRepository, IBaseRepository baseRepository)
        {
            _interactionRepository = interactionRepository;
            _messageRepository = messageRepository;
            _carRepository = carRepository;
            _contactRepository = contactRepository;
            _baseRepository = baseRepository;
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

        [HttpPost("start")]
        public async Task<IActionResult> StartInteractionAsync([FromBody] SendMessageViewModel messageViewModel)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Car subject = await _carRepository.GetCarByIdAsync(messageViewModel.SubjectId);
                string ownerId = subject.OwnerId;
                Contact contactFromUserThatCalled = await _contactRepository.GetContactAsync(userId);

                if (subject is null || contactFromUserThatCalled is null || userId == ownerId)
                    return BadRequest();

                Interaction interactionInDatabase = await _interactionRepository.GetInteractionWithAsync(userId,
                    ownerId, subject.Id);

                if (interactionInDatabase != null)
                {
                    Message newMessage = new(userId, ownerId, subject.Id, messageViewModel.Text);
                    await _baseRepository.AddAsync(newMessage);
                    return Ok();
                }

                Contact contact = await _contactRepository.GetContactAsync(ownerId);

                Interaction interaction = new(userId, ownerId, contact.FirstName, contact.LastName, subject.Id);
                Interaction interaction1 = new(ownerId, userId, contactFromUserThatCalled.FirstName, 
                    contactFromUserThatCalled.LastName, subject.Id);
                Message firstMessage = new(userId, ownerId, subject.Id, messageViewModel.Text);

                await _baseRepository.AddAsync(interaction);
                await _baseRepository.AddAsync(interaction1);
                await _baseRepository.AddAsync(firstMessage);

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
