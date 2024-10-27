using CarBook.Application.Enums;
using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppuserHandlers
{
    public class CreateAppUserCommandHandler:IRequestHandler<CreateAppUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser()
            {
                Username=request.Username,
                Password=request.Password, 
                AppRoleId=(int)Roletypes.Member,
                Name=request.Name,
                LastName=request.LastName,
                Email=request.Email,
            });
        }
    }
}
