using CarBook.Application.Features.Mediator.Responses.CarFeatureResponses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQueryRequest:IRequest<List<GetCarFeatureByCarIdQueryResponse>>
    {
        public GetCarFeatureByCarIdQueryRequest(int carID)
        {
            CarID = carID;
        }

        public int CarID { get; set; }
    }
}
