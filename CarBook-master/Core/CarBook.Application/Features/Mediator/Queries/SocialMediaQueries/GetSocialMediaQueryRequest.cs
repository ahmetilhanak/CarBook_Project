using CarBook.Application.Features.Mediator.Responses.SocialMediaResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQueryRequest:IRequest<List<GetSocialMediaQueryResponse>>
    {
    }
}
