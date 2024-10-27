using CarBook.Application.Features.Mediator.Responses.AppUserRessponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQueryRequest:IRequest<GetCheckAppUserQueryResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
