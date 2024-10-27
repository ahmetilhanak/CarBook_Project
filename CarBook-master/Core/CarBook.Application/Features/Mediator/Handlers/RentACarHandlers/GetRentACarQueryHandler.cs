using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Responses.RentACarResponses;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQueryRequest, List<GetRentACarQueryResponse>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarQueryResponse>> Handle(GetRentACarQueryRequest request, CancellationToken cancellationToken)
        {
            var values = _rentACarRepository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Avaliable == request.Avaliable);

            return values.Select(z => new GetRentACarQueryResponse()
            {
                //RentACarID = z.RentACarID,
                //LocationID = z.LocationID,
                //Avaliable = z.Avaliable,
                CarId = z.CarId
            }).ToList();
        }
    }
}
