using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Responses.LocationResponses
{
    public class GetLocationByIdQueryResponse
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
    }
}
