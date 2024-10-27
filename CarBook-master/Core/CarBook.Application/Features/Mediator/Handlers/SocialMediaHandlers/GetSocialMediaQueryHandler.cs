using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Responses.SocialMediaResponse;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQueryRequest, List<GetSocialMediaQueryResponse>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResponse>> Handle(GetSocialMediaQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetSocialMediaQueryResponse()
            {
                SocialMediaID=z.SocialMediaID,
                Icon=z.Icon,
                Name=z.Name,
                Url=z.Url,
            }).ToList();
        }
    }
}
