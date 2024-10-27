using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetLastSomeCarsWithBrandQuery
    {
        public GetLastSomeCarsWithBrandQuery(int carCount)
        {
            CarCount = carCount;
        }

        public int CarCount { get; set; }
    }
}
