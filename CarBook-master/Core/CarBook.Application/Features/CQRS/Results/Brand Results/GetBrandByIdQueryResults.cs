﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.Brand_Results
{
    public class GetBrandByIdQueryResults
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}