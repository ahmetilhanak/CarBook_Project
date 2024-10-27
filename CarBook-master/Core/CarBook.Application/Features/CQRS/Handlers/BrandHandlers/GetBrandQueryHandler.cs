using CarBook.Application.Features.CQRS.Results.Brand_Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResults>> Handle()
        {
           var values = await _repository.GetAllAsync();

            return values.Select(z => new GetBrandQueryResults()
            {
                BrandID = z.BrandID,
                Name = z.Name,
            }).ToList();
        }
    }
}
