using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDto
{
    public class GetFeaturesOfCarByCarIdDto
    {
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
