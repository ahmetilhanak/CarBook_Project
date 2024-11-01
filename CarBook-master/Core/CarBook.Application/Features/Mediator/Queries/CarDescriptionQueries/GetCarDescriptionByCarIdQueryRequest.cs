﻿using CarBook.Application.Features.Mediator.Responses.CarDescriptionResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQueryRequest:IRequest<GetCarDescriptionQueryResponse>
    {
        public GetCarDescriptionByCarIdQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
