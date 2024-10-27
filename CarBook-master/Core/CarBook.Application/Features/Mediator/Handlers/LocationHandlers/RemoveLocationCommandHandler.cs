﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommandRequest>
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);
        }
    }
}
