﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommandRequest: IRequest
    {
        public string Title { get; set; }
        public int BlogID { get; set; }
    }
}
