﻿using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(z => new GetContactQueryResult()
            {
                ContactID=z.ContactID,
                Email=z.Email,
                Message=z.Message,
                Name=z.Name,
                SendDate=z.SendDate,
                Subject=z.Subject,
            }).ToList();
        }
    }
}
