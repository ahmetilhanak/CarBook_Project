﻿using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z=>new GetBannerQueryResult(){
                BannerID=z.BannerID,
                Description=z.Description,
                Title=z.Title,
                VideoDescription=z.VideoDescription,
                VideoUrl=z.VideoUrl,
            }).ToList();
        }
    }
}