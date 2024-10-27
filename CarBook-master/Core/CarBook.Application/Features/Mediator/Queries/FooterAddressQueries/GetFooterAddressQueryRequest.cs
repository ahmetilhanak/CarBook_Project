using CarBook.Application.Features.Mediator.Responses.FooterAddressResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQueryRequest:IRequest<List<GetFooterAddressQueryResponse>>
    {
    }
}
