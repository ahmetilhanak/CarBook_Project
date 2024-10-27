﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommandRequest:IRequest
    {
        public RemoveFooterAddressCommandRequest(int id)
        {
            Id = id;
        }

        public  int Id{ get; set; }
    }
}