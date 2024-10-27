using CarBook.Application.Features.Mediator.Responses.StatisticResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountByFuelElectricQueryRequest:IRequest<GetCarCountByFuelElectricQueryResponse>
    {
    }
}
