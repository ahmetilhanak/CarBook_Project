using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommandRequest:IRequest 
    {
        public RemoveLocationCommandRequest(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
