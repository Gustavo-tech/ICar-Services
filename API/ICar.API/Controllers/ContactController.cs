using ICar.API.ControllerExtensions;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.ViewModels.Input;
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
    public class ContactController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IContactRepository _contactRepository;

        public ContactController(IBaseRepository baseRepository, IContactRepository contactRepository)
        {
            _baseRepository = baseRepository;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyContactAsync()
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Contact contact = await _contactRepository.GetContactAsync(userId);

                if (contact is null)
                    return NotFound();

                return Ok(contact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddContactAsync([FromBody] InsertContactViewModel viewModel)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Contact contact = await _contactRepository.GetContactAsync(userId);

                if (contact is null)
                {
                    Contact newContact = new(userId, viewModel.Nickname, viewModel.PhoneNumber, 
                        viewModel.EmailAddress);

                    await _baseRepository.AddAsync(newContact);
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

        [HttpPut]
        public async Task<IActionResult> UpdateContactAsync([FromBody] UpdateContactViewModel viewModel)
        {
            try
            {
                string userId = HttpContext.GetUserObjectId();
                Contact contact = await _contactRepository.GetContactAsync(userId);

                if (contact is null)
                    return BadRequest();

                contact.Update(viewModel);
                await _baseRepository.UpdateAsync(contact);
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
