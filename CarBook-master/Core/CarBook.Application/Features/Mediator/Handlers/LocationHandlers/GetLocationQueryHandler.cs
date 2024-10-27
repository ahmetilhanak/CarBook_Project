﻿using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Responses.LocationResponses;
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
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQueryRequest, List<GetLocationQueryResponse>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResponse>> Handle(GetLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetLocationQueryResponse()
            {
                LocationID=z.LocationID,
                Name=z.Name,
            }).ToList();
        }
    }
}
