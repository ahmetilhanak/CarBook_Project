using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler:IRequestHandler<UpdateServiceCommandRequest>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Service()
            {
                Title = request.Title,
                IconUrl = request.IconUrl,
                Description = request.Description,
            });
        }

        public async Task Handle(UpdateServiceCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceID);

            value.Description= request.Description;
            value.Title= request.Title;
            value.IconUrl= request.IconUrl;

            await _repository.UpdateAsync(value); 
        }
    }
}
