﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Responses.RentACarResponses
{
    public class GetRentACarByIdQueryResponse
    {
        public int RentACarID { get; set; }
        public int LocationID { get; set; }
        public int CarId { get; set; }
        public bool Avaliable { get; set; }
    }
}
