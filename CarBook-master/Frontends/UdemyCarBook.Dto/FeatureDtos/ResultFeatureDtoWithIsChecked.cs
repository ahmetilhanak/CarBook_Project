using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.FeatureDtos
{
    public class ResultFeatureDtoWithIsChecked
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
