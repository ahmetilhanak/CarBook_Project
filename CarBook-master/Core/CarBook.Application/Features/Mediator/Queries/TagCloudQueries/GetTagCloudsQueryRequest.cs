﻿using CarBook.Application.Features.Mediator.Responses.TagCloudResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudsQueryRequest:IRequest<List<GetTagCloudsQueryResponse>>
    {
    }
}
