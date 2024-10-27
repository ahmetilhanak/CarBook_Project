using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getBannerByIdQuery.Id);

            return new GetBannerByIdQueryResult()
            {
               BannerID=value.BannerID,
               Description=value.Description,
               Title=value.Title,
               VideoDescription= value.VideoDescription,
               VideoUrl = value.VideoUrl            
            };

        }
    }
}
