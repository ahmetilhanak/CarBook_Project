using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand updateContactCommand)
        {
            var value = await _repository.GetByIdAsync(updateContactCommand.ContactID);

            value.Email=updateContactCommand.Email;
            value.SendDate = updateContactCommand.SendDate;
            value.Subject=updateContactCommand.Subject;
            value.Name=updateContactCommand.Name;
            value.Message=updateContactCommand.Message;

            await _repository.UpdateAsync(value);
        }
    }
}
