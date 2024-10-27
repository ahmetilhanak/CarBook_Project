using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Responses.FeatureResponses
{
    public class GetFeatureByIdQueryResponse
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
    }
}
