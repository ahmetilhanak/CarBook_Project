﻿using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Responses.BlogResponses
{
    public class GetBlogQueryResponse:IRequest
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }       
        public string CoverImageUrl { get; set; }
        public int CategoryID { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }
    }
}