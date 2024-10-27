using CarBook.Application.Features.CQRS.Queries.BrandQueries;
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
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResults> Handle(GetBrandByIdQuery getBrandByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getBrandByIdQuery.Id);

            return new GetBrandByIdQueryResults()
            {
                BrandID=value.BrandID,
                Name=value.Name    
            };
            
        }
    }
}
