using CarBook.Application.Features.Mediator.Responses.RentACarResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQueryRequest:IRequest<List<GetRentACarQueryResponse>>
    {
        public GetRentACarQueryRequest(int locationID, bool avaliable)
        {
            LocationID = locationID;
            Avaliable = avaliable;
        }

        public int LocationID { get; set; }
        public bool Avaliable { get; set; }

    }
}
