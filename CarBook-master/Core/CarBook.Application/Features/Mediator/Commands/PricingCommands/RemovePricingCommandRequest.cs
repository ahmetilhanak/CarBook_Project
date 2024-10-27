using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommandRequest:IRequest
    {
        public RemovePricingCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
