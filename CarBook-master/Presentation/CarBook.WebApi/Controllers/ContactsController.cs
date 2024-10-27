using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("It is Added");
        }

        [HttpDelete("[action]/{id}")]

        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));

            return Ok("It is deleted");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand updateContactCommand)
        {
            await _updateContactCommandHandler.Handle(updateContactCommand);
            return Ok("It is Updated");
        }
    }
}
