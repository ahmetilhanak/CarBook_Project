using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommandRequest:IRequest
    {
        public RemoveTagCloudCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
